
//#region [ VARIABLE ]

const ___ROOT_IMAGE = 'C:/Git/OCR/OCR_Accord.Tesseract/data-test/cmt';
const ___PORT_API = 1502
const ___URL_OCR_ENGINE = 'http://127.0.0.1:1501?files=';

const _NET = require('net');
const _PATH = require('path');
const _FS = require('fs');
const _URL = require('url');

const _JOB = require('cron').CronJob;

const _FETCH = require('node-fetch');
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;

var _REQUEST = require('request');
var _PROGRESS = require('request-progress');

const ___DOWNLOAD_IMAGE = function (uri, path, onProgress, onResponse, onError, onEnd) {
    _PROGRESS(_REQUEST(uri))
        .on('progress', onProgress)
        .on('response', onResponse)
        .on('error', onError)
        .on('end', onEnd)
        .pipe(_FS.createWriteStream(path))
};

//----------------------------------------------------------------------------

let IP___LOCAL = '';
const _OS = require('os');
const _IFACES = _OS.networkInterfaces();

Object.keys(_IFACES).forEach(function (ifname) {
    _IFACES[ifname].forEach(function (iface) {
        if ('IPv4' !== iface.family || iface.internal !== false) {
            // skip over internal (i.e. 127.0.0.1) and non-ipv4 addresses
            return;
        }
        //console.log(iface.address);
        if (iface.address && iface.address.indexOf('192.168.') != -1) IP___LOCAL = iface.address;
    });
});
console.log('-> IP = ' + IP___LOCAL);

//#endregion

//#region [ BASE ]

const ___guid = function () {
    return 'id-xxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
};

const ___yyyyMMddHHmmss = function () {
    return (new Date().toISOString().slice(-24).replace(/\D/g, '').slice(0, 8)) + (new Date().toTimeString().split(' ')[0].replace(/\D/g, ''));
};
//#endregion

//#region [ JOB ]

const ___MSG_INPUT = [];
const ___MSG_OUTPUT = {};
new _JOB('* * * * * *', async function () {
    if (___MSG_INPUT.length > 0) {
        const m = ___MSG_INPUT.shift();
        if (m) {
            const id = m.id, front_side = m.front_side, back_side = m.back_side, client = m.client;

            const time_ = ___yyyyMMddHHmmss();
            let a1 = front_side.split('/');
            let f1 = a1[a1.length - 1];
            let a2 = back_side.split('/');
            let f2 = a2[a2.length - 1];
            a1 = f1.split('.');
            f1 = f1.substr(0, f1.length - a1[a1.length - 1].length - 1) + '_' + time_ + '.' + a1[a1.length - 1];
            a2 = f2.split('.');
            f2 = f2.substr(0, f2.length - a2[a2.length - 1].length - 1) + '_' + time_ + '.' + a2[a2.length - 1];

            //console.log(f1, f2);

            ___DOWNLOAD_IMAGE(front_side, f1, function (state1) {
                console.log("progress", state1);
            }, function (response1) {
                console.log("status code", response1.statusCode);
            }, function (error1) {
                console.log("error", error1);
                client.json({ ok: false });
            }, function () {
                console.log("done");
                //client.json({ ok: true });

                ___DOWNLOAD_IMAGE(back_side, f2, function (state2) {
                    console.log("progress", state2);
                }, function (response2) {
                    console.log("status code", response2.statusCode);
                }, function (error2) {
                    console.log("error", error2);
                    client.json({ ok: false });
                }, function () {
                    console.log("done");

                    const key = f1 + ';' + f2;
                    console.log(key);
                    ___MSG_OUTPUT[key] = client;

                        _FETCH(___URL_OCR_ENGINE + key)
                            .then(res => res.text())
                            .then(text => {
                                console.log(text);
                                if (text == 'INTERNAL_SERVER_ERROR' || text == 'NOT_FOUND') {

                                    if (___MSG_OUTPUT[key]) {
                                        ___MSG_OUTPUT[key].json({ ok: false, message: text });
                                        delete ___MSG_OUTPUT[key];
                                    }

                                }
                            });
                });

            });
        }
    }
}).start();

//#endregion


//#region [ API ]

const _HTTP_EXPRESS = require('express');
const _HTTP_BODY_PARSER = require('body-parser');
const _HTTP_APP = _HTTP_EXPRESS();

const _HTTP_SERVER = require('http').createServer(_HTTP_APP);

_HTTP_APP.use(_HTTP_BODY_PARSER.json());
_HTTP_APP.use((error, req, res, next) => {
    if (error !== null) {
        return res.json({ ok: false, mesage: 'Invalid json ' + error.toString() });
    }
    return next();
});
_HTTP_APP.use(_HTTP_EXPRESS.static(_PATH.join(__dirname, 'www')));

_HTTP_APP.get('/api/test', function (req, res) {
    res.json({ ok: true, time: new Date() });
});

_HTTP_APP.get('/api/ocr', function (req, res) {
    let front_side = '', back_side = '';
    if (req.query.front_side) front_side = req.query.front_side;
    if (req.query.back_side) back_side = req.query.back_side;

    if (back_side.length > 0 && front_side.length > 0) {
        ___MSG_INPUT.push({ id: ___guid(), front_side: front_side, back_side: back_side, client: res });
    } else {
        res.json({ ok: false, message: 'Url format are as follow: api/ocr?front_side=http://...&back_side=http://...' });
    }
});

_HTTP_APP.post('/api/ocr-cef', function (req, res) {
    const o = req.body;
    console.log(o);
    
    if (o && o.files && o.files.length == 2) {
        const key = o.files.join(';');
        if (___MSG_OUTPUT[key]) {
            ___MSG_OUTPUT[key].json(o);
            delete ___MSG_OUTPUT[key];
        }
    }

    res.json({ ok: true, time: new Date() });
});

_HTTP_SERVER.listen(___PORT_API);

//#endregion
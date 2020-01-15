document.body.style.overflow = 'hidden';

var d = document.createElement('div');
d.style = 'width: 100%; height: 100vh; position: fixed; left: 0px; top: 0px; z-index: 2147483000; background-color: black;';
document.body.appendChild(d);

var f = document.querySelectorAll('iframe')[0];
f.style = 'width: 1px; min-width: 100%; height: 342px; position: fixed; left: 0px; top: 0px; z-index: 2147483647; background-color: black;';
f.contentWindow.document.body.style = 'overflow: hidden !important;';

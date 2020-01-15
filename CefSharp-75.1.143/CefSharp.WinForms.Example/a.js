
console.log('?????????????????? = ', new Date().toLocaleString());

window.addEventListener('DOMContentLoaded', (event) => {
    //document.body.style.overflow = 'hidden !important';

    //setTimeout(function () {
        var f = document.querySelectorAll('iframe')[0];
        f.style = 'width: 1px; min-width: 100%; height: 342px; position: fixed; left: 0px; top: 0px; z-index: 2147483647; background-color: black;';
        f.contentWindow.document.body.style = 'overflow: hidden !important;';
         
        var d = document.createElement('div');
        d.style = 'width: 100%; height: 100vh; position: fixed; left: 0px; top: 0px; z-index: 2147483000; background-color: black;';
        //d.style = 'width: 100%; height: 100vh; position: fixed; left: 0px; top: 0px; z-index: 2147483647; background-color: transparent;';
        document.body.appendChild(d);

    //}, 1500);
});
 
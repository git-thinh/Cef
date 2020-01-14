
console.log('?????????????????? = ', new Date().toLocaleString());

window.addEventListener('DOMContentLoaded', (event) => {
    var f = document.querySelectorAll('iframe')[0];
    f.style = 'width: 1px; min-width: 100%; height: 342px; position: fixed; left: 0px; top: 0px; z-index: 2147483647; background-color: red;';

    var app = f.contentWindow.document.querySelector('vs-app');
    console.log(app);
    app.click();





});
 
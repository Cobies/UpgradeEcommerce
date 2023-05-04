function AgregarModal() {
    const demoClasses = document.querySelectorAll('.modinput');
    demoClasses.forEach(element => {
        element.removeAttribute("readonly");
    });
    
    $("input[name='_id']").val("");
    const clase2 = document.querySelectorAll('.modselect');
    clase2.forEach(element => {
        element.setAttribute("data-bs-toggle", "dropdown");
    });
    const clase3 = document.querySelectorAll('.inhabilitarbtn');
    clase3.forEach(element => {
        element.removeAttribute("disabled", true);
    });
}
function EditarModal() {

    const demoClasses = document.querySelectorAll('.modinput');
    demoClasses.forEach(element => {
        element.removeAttribute("readonly");
    });
    
    const clase2 = document.querySelectorAll('.modselect');
    clase2.forEach(element => {
        element.setAttribute("data-bs-toggle", "dropdown");
    });
    const clase3 = document.querySelectorAll('.inhabilitarbtn');
    clase3.forEach(element => {
        element.removeAttribute("disabled", true);
    });

}
function VisualizarModal() {

    const demoClasses = document.querySelectorAll('.modinput');
    demoClasses.forEach(element => {
        element.setAttribute("readonly", true);
    });
    const clase2 = document.querySelectorAll('.modselect');
    clase2.forEach(element => {
        element.removeAttribute("data-bs-toggle");
    });
    const clase3 = document.querySelectorAll('.inhabilitarbtn');
    clase3.forEach(element => {
        element.setAttribute("disabled",true);
    });
 
}
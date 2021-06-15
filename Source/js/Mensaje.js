/********************PARA EL MENSAJE DEL IMC*********************************/
var mensaje = document.getElementById("mensaje").innerHTML;

if (mensaje == "Si") {
    var toastCount = 0;
    var shortCutFunction = "success";
    var msg = "Todos sus datos esta correctos";
    var title = "GGYM";
    var $showDuration = 300;
    var toastIndex = toastCount++;

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    $('#toastrOptions').text('Command: toastr["'
        + shortCutFunction
        + '"]("'
        + msg
        + (title ? '", "' + title : '')
        + '")\n\ntoastr.options = '
        + JSON.stringify(toastr.options, null, 2)
    );

    var $toast = toastr[shortCutFunction](msg, title);

    css = "alert-success";

} else if (mensaje == "No") {
    var toastCount = 0;
    var shortCutFunction = "warning";
    var msg = "Datos del usuario faltantes.";
    var title = "GGYM";
    var $showDuration = 300;
    var toastIndex = toastCount++;

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    $('#toastrOptions').text('Command: toastr["'
        + shortCutFunction
        + '"]("'
        + msg
        + (title ? '", "' + title : '')
        + '")\n\ntoastr.options = '
        + JSON.stringify(toastr.options, null, 2)
    );

    var $toast = toastr[shortCutFunction](msg, title);

} else if (mensaje == "Mucho") {
    var toastCount = 0;
    var shortCutFunction = "error";
    var msg = "Muchos datos faltantes";
    var title = "GGYM";
    var $showDuration = 300;
    var toastIndex = toastCount++;

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    $('#toastrOptions').text('Command: toastr["'
        + shortCutFunction
        + '"]("'
        + msg
        + (title ? '", "' + title : '')
        + '")\n\ntoastr.options = '
        + JSON.stringify(toastr.options, null, 2)
    );

    var $toast = toastr[shortCutFunction](msg, title);
}
$(document).ready(function () {
    $("body").on('click', 'button', function () {

        // Si el boton no tiene el atributo ajax no hacemos nada
        if ($(this).data('ajax') == undefined) return;

        // El metodo .data identifica la entrada y la castea al valor más correcto
        if ($(this).data('ajax') != true) return;

        var form = $(this).closest("form");

        var buttons = $("button", form);
        var button = $(this);
        var url = form.attr('action');

        if (button.data('confirm') != undefined)
        {
            if (button.data('confirm') == '') {
                if (!confirm('¿Esta seguro de realizar esta acción?')) return false;
            } else {
                if (!confirm(button.data('confirm'))) return false;
            }
        }

        if (button.data('delete') != undefined)
        {
            if (button.data('delete') == true)
            {
                url = button.data('url');
            }
        }else
        {
            if (!form.valid()) {
                return false;
            }
        }

        // Creamos un div que bloqueara todo el formulario
        var block = $('<div class="block-loading" />');
        form.prepend(block);

        // En caso de que haya habido un mensaje de alerta
        $(".alert", form).remove();

        // Para los formularios que tengan CKupdate
        if (form.hasClass('CKupdate')) CKupdate();

        form.ajaxSubmit({
            dataType: 'JSON',
            type: 'POST',
            url: url,
            success: function (r) {
                block.remove();
                if (r.response) {
                    if (!button.data('reset') != undefined) {
                        if (button.data('reset')) form.reset();
                    }
                    else
                    {
                        form.find('input:file').val('');
                    }
                }

                // Mostrar mensaje
                if (r.message != null) {
                    if (r.message.length > 0) {
                        var css = "";
                        if (r.response) {
                            var toastCount = 0;
                            var shortCutFunction = "success";
                            var msg = "Bienvenido";
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
                        }
                        else {

                            //Mensaje de usuario
                            var toastCount = 0;
                            var shortCutFunction = "error";
                            var msg = "Usuario y/o contraseña incorrectos";
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
                        };                 
                    }
                }

                // Ejecutar funciones
                if (r.function != null) {
                    setTimeout(r.function, 0);
                }
                // Redireccionar
                if (r.href != null) {
                    if (r.href == 'self') window.location.reload(true);
                    else window.location.href = r.href;
                }
            },
            error: function(jqXHR, textStatus, errorThrown){
                block.remove();
                form.prepend('<div class="alert alert-warning alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + errorThrown + ' | <b>' + textStatus + '</b></div>');
            }
        });

        return false;
    })
})

jQuery.fn.reset = function () {
    $("input:password,input:file,input:text,textarea", $(this)).val('');
    $("input:checkbox:checked", $(this)).click();
    $("select").each(function () {
        $(this).val($("option:first", $(this)).val());
    })
};
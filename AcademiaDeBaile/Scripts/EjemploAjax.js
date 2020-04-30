function Detalles(id) {
    $.ajax({
        'url': 'https://'+  window.location.host +'/Instructor/Detalles/' + id,
        'type': 'get',
        //Que tipo de dato estoy trasmitiendo y voy a recibir
        'dataType': 'json',

        //Funcion JS anonima    
        'success': function (datos) {
            var contenido = '<b>Cédula: </b>' + datos.Cedula + '<br />' +
                '<b>Nombre: </b>' + datos.Nombre + ' ' + datos.Apellidos + '<br />' +
                '<b>Experiencia (años): </b>' + datos.AñosExperiencia + '<br />' +
                '<b>Fecha de Nacimiento (años): </b>' + datos.FechaNacimiento + '<br />' +
                '<b>Experto en:  (años): </b>' + datos.ExpertoEn + '<br />';

                $('#modal1 > .modal-content > p').html(contenido);

            $('.modal').modal();
            $('.modal').modal('open');

        },
        //
        'error': function (datos) {
            alert('Ocurrió un Error');
        }
    });
}

function LoguearUsuario() {
    $.ajax({
        'url': 'https://' + window.location.host + '/Home/LoginUsuario',
        //post = el sistema no manda los datos por encima, los manda por debajo
        'type': 'post',
        'dataType': 'json',
        'data': "usuario=" + $('#NombreUsuario').val() + "&password=" + $('#PasswordUsuario').val(),
        'success': function (datos) {
            if (datos.Error) {
                $('.modal > .modal-content > p').html(datos.Error);
                $('.modal').modal();
                $('.modal').modal('open');
            } else {
                window.location.href = "https://" + window.location.host + "/Home/Index";
            }
        },
        'error': function (datos) {
            $('.modal').modal();
            $('.modal').modal('open');
        }



        //'success': function (datos) {
        //    console.log(datos);
        //    if (datos.NombreUsuario) {

        //        location.href = 'https://'+  window.location.host +'/Home/Index';

        //    } else {
        //        var respuesta = JSON.parse(datos);
        //        if (respuesta.Error) {

        //            $('#modal2 > .modal-content > p').html(respuesta.Error);

        //            $('.modal').modal();
        //            $('.modal').modal('open');
        //        } 
        //    }
            
            
        //},
        //'error': function (datos) {
        //    alert('Respuesta FAIL')
        //}
    });
}
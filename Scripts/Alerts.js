function mostrarAlerta(mensaje, tipoIcono) {
    let icono;
    switch (tipoIcono) {
        case 'success':
            icono = 'success';
            break;
        case 'error':
            icono = 'error';
            break;
        case 'warning':
            icono = 'warning';
            break;
        default:
            icono = 'info';
            break;
    }

    Swal.fire({        
        text: mensaje,
        icon: icono,
        confirmButtonText: 'OK'
    });
}
(function (appRestaurante) {
    appRestaurante.getModal = getModalContent;

    function getModalContent(url, tamanio) {
        $.get(url, function (data) {
            $('#modal-dialog-id').removeClass('modal-xl');
            $('#modal-dialog-id').removeClass('modal-lg');
            $('#modal-dialog-id').removeClass('modal-md');
            $('#modal-dialog-id').removeClass('modal-sm');
            $('#modal-dialog-id').addClass(tamanio);
            $('#modal-dialog-id').find('.modal-body').html(data);
        })
    }
  

})(window.appRestaurante = window.appRestaurante || {})
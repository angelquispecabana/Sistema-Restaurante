(function (appRestaurante) {
    appRestaurante.getModal = getModalContent;

    function getModalContent(url) {
        $.get(url, function (data) {
            $('.modal-body').html(data);
        })
    }
})(window.appRestaurante = window.appRestaurante || {})
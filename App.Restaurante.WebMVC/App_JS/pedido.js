(function (pedido) {
    pedido.success = successReload;
    pedido.searchByFilter = searchByFilter;

    initPaginacion();

    function successReload(option) {
        appRestaurante.closeModal(option);
    }

    function initPaginacion() {
        $('#pedidoTable').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "autoWidth": false,
            "responsive": false/*,
            "buttons":["copy","csv","excel","pdf"]*/
        });//.buttons().container().appenTo("#categoriaTable");
    }

    function searchByFilter() {
        var desde = document.getElementById("desde");
        var hasta = document.getElementById("hasta");

        var url = 'Pedido/ListByFilters/?desde=' + desde.value + '&&hasta=' + hasta.value;
        $.get(url, function (data) {
            $('#pedidoList').html(data);
            initPaginacion();
        })
    }

})(window.pedido = window.pedido || {})
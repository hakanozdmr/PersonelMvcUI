$(function () {

    $("#tblDepartmanlar").DataTable(
        {
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        });

    $("#tblPersoneller").DataTable(
        {
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        });
        $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
            var btn = $(this);
            bootbox.confirm({
                closeButton:false,
                title: "DEPARTMAN SİL",
                message: "Departmanı Silmek İstediğinize Emin misiniz?",
                buttons: {
                    cancel: {
                        label: '<i class="fa fa-times"></i> İptal'
                    },
                    confirm: {
                        label: '<i class="fa fa-check"></i> Sil'
                    }
                },
                callback: function (result) {
                    var id = btn.data("id");
                    if (result) {
                        $.ajax({
                            type: "GET",
                            url: "/Departman/Sil/" + id,
                            success: function () {
                                btn.parent().parent().remove();
                            }
                        });

                    }
                 
                }

            });
        });

        $("#tblPersoneller").on("click", ".btnPersonelSil", function () {
            var btn = $(this);
            bootbox.confirm({
                closeButton:false,
                title: "PERSONEL SİL",
                message: "Personeli Silmek İstediğinize Emin misiniz?",
                buttons: {
                    cancel: {
                        label: '<i class="fa fa-times"></i> İptal'
                    },
                    confirm: {
                        label: '<i class="fa fa-check"></i> Sil'
                    }
                },
                callback: function (result) {
                    var id = btn.data("id");
                    if (result) {
                        $.ajax({
                            type: "GET",
                            url: "/Personel/Sil/" + id,
                            success: function () {
                                btn.parent().parent().remove();
                            }
                        });
                    }

                }

            });
        });

});
function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value == '') {
        $(dateElement).valid("false");
    }
    else {
        $(dateElement).valid();
    }
}
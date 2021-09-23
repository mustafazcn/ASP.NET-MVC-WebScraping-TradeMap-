$(document).ready(function () {
   
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        if (mode === "ProcEkleIslem") {
            $(buton).data('url', "/Selenium/ProcEkleIslem/");
            var mail = $("txtMail").val();
            var sifre = $("txtSifre").val();
            var procUlkeAd = $("#txtProcUlkeAd").val();
            formData.append("ProcUlkeAd", $(buton).data("data1"));
            ButtonExecute("post", "#form1", this, formData, function (result) {
                alert(ulkeAd);
            }, function () { }, "false", "");
        }


        if (mode === "EkleIslem") {
            $(buton).data('url', "/Selenium/EkleIslem/");
            var ulkeAd = $("#txtUlkeAd").val();
            formData.append("UlkeAd", $(buton).data("data1"));
            ButtonExecute("post", "#form2", this, formData, function (result) {
                alert(ulkeAd);
            }, function () { }, "false", "");
        }



        
       




        
    });
});
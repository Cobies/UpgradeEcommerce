        function movimientosiguiente() {

            var numelement = document.getElementById("numelement").value;
            var num = parseInt(numelement);

            num += 20;
            var numinicial = num + 1;
            var numfinal = num + 20;

            $("#cantelemento").html(" ");
            $("#cantelemento").append(numinicial + " - " + numfinal);
            $("input[name='numelement']").val(num);
            rellenartabla();
        }


        function movimientoanterior() {

            var numelement = document.getElementById("numelement").value;
            var num = parseInt(numelement);

            if (num != 0) {
                num -= 20;
                var numinicial = num + 1;
                var numfinal = num + 20;

                $("#cantelemento").html(" ");
                $("#cantelemento").append(numinicial + " - " + numfinal);
                $("input[name='numelement']").val(num);
                rellenartabla();

            }
        }


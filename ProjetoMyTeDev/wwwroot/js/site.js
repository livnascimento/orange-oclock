document.querySelector('#salvar-horas').addEventListener('click', function (e) {
    e.preventDefault();

    let quinzenaAtual = [], wbs = [], horas = [], registros = [];
    let temZero = false;

    document.querySelectorAll('.d-none').forEach((dia, index) => {
        dia = dia.textContent;
        dia = new Date(dia);

        quinzenaAtual.push(dia);
    })

    document.querySelectorAll(".wbs-select").forEach((wbsSelect, index) => {
        let selectedOption = wbsSelect.options[wbsSelect.selectedIndex];

        if (selectedOption.value != "WBS") {
            wbs.push({ wbsId: selectedOption.value, row: index })
        }
    })

    document.querySelectorAll(".registro-diario").forEach((DailyRegister, index) => {
        if (DailyRegister.value == 0)
            temZero = true;
        horas.push({ id: index, hours: DailyRegister.value, row: Math.floor(index / quinzenaAtual.length), col: (index % quinzenaAtual.length) });
    })

    if (temZero) {
        let toastHTMLElement = document.querySelector("#daily-register-toast");
        let toastBody = document.querySelector(".toast-body");
        toastBody.innerHTML= "Hora(s) inválida(s)"
        let toastElement = new bootstrap.Toast(toastHTMLElement);
        toastElement.show();
        return;
    }

    let idsValidos = horas.some(hora => wbs.some(wbs => wbs.row == hora.row));

    if (!idsValidos)
        return alert('WBS inválida selecionada.');

    horas.forEach(hora => {

        if (hora.hours != '') {
            let registro = {};
            registro.Horas = hora.hours;
            registro.Data = hora.col + quinzenaAtual[0].getDate();
            registro.WbsId = wbs.find(e => e.row == hora.row).wbsId;
            registros.push(registro);
        }
    })

    registros.forEach(e => console.log("elemento -> ", e));


    //fetch('/RegistroDiario/Create', {
    //    method: 'POST',
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    body: JSON.stringify(registros)
    //}).then(function (response) {
    //    if (response.ok) {
    //        alert('Dados salvos com sucesso!');
    //    } else {
    //        alert('Ocorreu um erro ao salvar os dados.');
    //    }
    //});
});

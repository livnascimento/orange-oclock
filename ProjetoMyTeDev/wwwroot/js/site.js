document.querySelector('#salvar-horas').addEventListener('click', function (e) {
    e.preventDefault();

    let quinzenaAtual = [], wbs = [], horas = [], registros = [];
    let erro = "";

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

    wbs.forEach(codigo => {
        let wbsRepetidos = wbs.filter(w => w.wbsId == codigo.wbsId);

        if (wbsRepetidos.length > 1) {
            erro = "Uma WBS deve ser selecionada apenas uma vez."
            return;
        }
    });

    if (erro != "") {
        exibirToast(erro);
        return;
    }

    document.querySelectorAll(".registro-diario").forEach((DailyRegister, index) => {
        if (DailyRegister.value === '0')
            temZero = true;

        horas.push({ id: index, hours: DailyRegister.value, row: Math.floor(index / quinzenaAtual.length), col: (index % quinzenaAtual.length)});
    })

    horas.forEach(hora => {
        if (hora.hours !== '') {
            let correspondente = wbs.find(wb => wb.row === hora.row);
            if (!correspondente) {
                erro = "Selecione uma WBS válida para todos os registros";
                return;
            }
        }
        if (hora.hours == '0') {
            erro = "Registro de horas inválido";
            return;
        }
    });

    if (erro != "") {
        exibirToast(erro);
        return;
    }

    horas.forEach(hora => {
        if (hora.hours != '') {
            let registro = {};
            registro.Horas = hora.hours;
            registro.Data = hora.col + quinzenaAtual[0].getDate();

            registro.WbsId = wbs.find(e => e.row == hora.row).wbsId;
            registros.push(registro);
        }
    })

    registros.forEach(registro => {
        let diaRepetido = registros.filter(r => r.Data == registro.Data);

        if (diaRepetido.length > 1) {
            erro = "Um dia deve conter apenas um registro de horas";
            return;
        }
    })

    if (erro != "") {
        exibirToast(erro);
        return;
    }

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

const exibirToast = (erro) => {
    let toastHTMLElement = document.querySelector("#daily-register-toast");
    let toastBody = document.querySelector(".toast-body");
    toastBody.innerHTML = erro;
    let toastElement = new bootstrap.Toast(toastHTMLElement);
    toastElement.show();
}
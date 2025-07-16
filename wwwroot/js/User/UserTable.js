// wwwroot/js/User/UserTable.js

class UserTable {
    constructor() {
        // Aqui você pode inicializar propriedades se precisar

    }

    init() {
        // Aqui você pode inicializar o que for necessário quando chamar init()
        this.preencherIdades();
    }

    /**
     * Calcula a idade a partir da data de nascimento no formato 'yyyy-mm-dd' ou Date object.
     * @param {string|Date} dataNascimento - Data de nascimento, como string ou objeto Date.
     * @returns {number} - Idade calculada em anos.
     */
    calcularIdade(dataNascimento) {
        //se for string, converte para date
        const nascimento = (dataNascimento instanceof Date) ? dataNascimento : new Date(dataNascimento);

        //pega a data atual
        const hoje = new Date();

        //Calcula a diferençã de anos entre o ano atual e ano de nascimento
        let idade = hoje.getFullYear() - nascimento.getFullYear();

        //ajysta se ainda não fez aniversario no ano atual
        const mesHoje = hoje.getMonth();
        const diaHoje = hoje.getDate();

        const mesNascimento = nascimento.getMonth();
        const diaNascimento = nascimento.getDate();

        // Se o mês atual for menor que o mês de nascimento
        // Ou se for o mesmo mês mas o dia ainda não chegou
        if (mesHoje < mesNascimento || (mesHoje === mesNascimento && diaHoje < diaNascimento)) {
            idade--; // Subtrai 1 ano porque ainda não fez aniversário
        }
        return idade;
    }

    /**
    * Preenche as idades, utilizando a função calcular idade
    */
    preencherIdades() {
        // Seleciona todas as células da tabela que possuem o atributo data-nascimento
        const tdsNascimento = document.querySelectorAll("#tabelaUsuarios td[data-nascimento]");

        // Para cada célula encontrada
        tdsNascimento.forEach(td => {
            // Pega o valor da data de nascimento armazenado no atributo data-nascimento
            const dataNascimento = td.getAttribute("data-nascimento");

            // Calcula a idade usando a função calcularIdade da classe
            const idade = this.calcularIdade(dataNascimento);

            // Pega a próxima célula na mesma linha que será usada para mostrar a idade
            const tdIdade = td.nextElementSibling;

            // Se a próxima célula existir e tiver a classe 'idade'
            if (tdIdade && tdIdade.classList.contains("idade")) {
                // Preenche o conteúdo da célula com a idade calculada
                tdIdade.textContent = idade;
            }

        });

    }

}

// tornar global
window.UserTable = UserTable;

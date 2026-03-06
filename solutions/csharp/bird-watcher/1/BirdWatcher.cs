class BirdCount
{
    // Campo privado que armazena a contagem de pássaros por dia.
    // É preenchido pelo construtor e usado pelos métodos de instância.
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        // Recebe o array externo e armazena na instância via "this",
        // permitindo que os métodos acessem os dados depois.
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        // Método estático: não pertence a nenhuma instância,
        // por isso não tem acesso ao "this".
        // Os dados da semana passada são fixos (hardcoded),
        // pois não são fornecidos por parâmetro.
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        // "Hoje" é sempre o último elemento do array.
        // Como o tamanho pode variar, usamos Length - 1 para
        // chegar ao último índice dinamicamente.
        // Ex: array com 6 elementos → último índice é 5 (6 - 1)
        return this.birdsPerDay[this.birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        // Acessa o último elemento (mesmo raciocínio do Today())
        // e usa ++ para somar 1 diretamente no valor daquele índice.
        // É equivalente a: birdsPerDay[ultimo] = birdsPerDay[ultimo] + 1
        this.birdsPerDay[this.birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        // Percorre cada elemento do array com foreach.
        // Se encontrar qualquer valor igual a 0, retorna true imediatamente.
        // Se terminar o loop sem encontrar, significa que não há dia vazio,
        // então retorna false.
        foreach (int count in this.birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        // Edge case: se numberOfDays for 0 ou negativo, não há nada a somar.
        if (numberOfDays <= 0) return 0;

        // Math.Min protege contra numberOfDays maior que o array.
        // Ex: array tem 6 elementos mas numberOfDays é 10 → usa 6.
        int days = Math.Min(numberOfDays, this.birdsPerDay.Length);

        // Variável acumuladora: começa em 0 e vai somando cada elemento.
        int totalBirds = 0;

        // for usado no lugar de foreach pois precisamos de controle
        // sobre o índice — paramos em "days", não no fim do array.
        for (int i = 0; i < days; i++)
        {
            totalBirds += this.birdsPerDay[i];
        }

        return totalBirds;
    }

    public int BusyDays()
    {
        // Contador de dias agitados (5 ou mais pássaros).
        int busyDays = 0;

        // Percorre todos os elementos verificando a condição.
        // A cada elemento >= 5, incrementa o contador.
        for (int i = 0; i < this.birdsPerDay.Length; i++)
        {
            if (this.birdsPerDay[i] >= 5)
            {
                busyDays++;
            }
        }

        return busyDays;
    }
}
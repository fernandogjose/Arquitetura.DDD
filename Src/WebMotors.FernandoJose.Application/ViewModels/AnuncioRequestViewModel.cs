namespace WebMotors.FernandoJose.Application.ViewModels
{
    public class AnuncioAdicionarRequest : BaseRequest
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Versao { get; set; }

        public string Observacao { get; set; }

        public int Ano { get; set; }

        public int Quilometragem { get; set; }
    }

    public class AnuncioEditarRequest : BaseRequest
    {
        public int Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Versao { get; set; }

        public string Observacao { get; set; }

        public int Ano { get; set; }

        public int Quilometragem { get; set; }
    }

    public class AnuncioDeletarRequest : BaseRequest
    {
        public int Id { get; set; }
    }

    public class AnuncioObterRequest 
    {
        public int Id { get; set; }
    }

    public class AnuncioListarRequest
    {
        public string Marca { get; set; }
    }
}

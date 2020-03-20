namespace WebMotors.FernandoJose.Application.ViewModels
{
    public class AnuncioAdicionarResponse : BaseResponse
    {
        public int Id { get; set; }
    }

    public class AnuncioEditarResponse : BaseResponse
    {
    }

    public class AnuncioDeletarResponse : BaseResponse
    {
    }

    public class AnuncioObterResponse
    {
        public int Id { get; set; }

        public string Marca { get; private set; }

        public string Modelo { get; private set; }

        public string Versao { get; private set; }

        public string Observacao { get; private set; }

        public int Ano { get; private set; }

        public int Quilometragem { get; private set; }
    }

    public class AnuncioListarResponse
    {
        public int Id { get; set; }

        public string Marca { get; private set; }

        public string Modelo { get; private set; }

        public string Versao { get; private set; }

        public string Observacao { get; private set; }

        public int Ano { get; private set; }

        public int Quilometragem { get; private set; }
    }
}

namespace WebMotors.FernandoJose.Domain.Models
{
    public class Anuncio : Base
    {
        public string Marca { get; private set; }

        public string Modelo { get; private set; }

        public string Versao { get; private set; }

        public string Observacao { get; private set; }

        public int Ano { get; private set; }

        public int Quilometragem { get; private set; }
    }
}

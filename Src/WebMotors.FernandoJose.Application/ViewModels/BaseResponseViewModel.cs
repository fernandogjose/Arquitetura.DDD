using System.Collections.Generic;

namespace WebMotors.FernandoJose.Application.ViewModels
{
    public abstract class BaseResponse
    {
        public List<ErroViewModel> Erros { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("sistema-indisponivel")]
        public IActionResult SistemaIndisponivel()
        {
            var modelErro = new ErrorViewModel
            {
                Mensagem =
                    "O Sistema está temporariamente indisponível, isto pode ocorrer em momentos de sobrecarga de usuários.",
                Titulo = "Sistema Indisponível",
                ErroCode = 500
            };

            return View("Error", modelErro);
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate o nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
            }
            else if (id == 404)
            {
                modelErro.Mensagem =
                    "A página que está procurando não existe! <br /> Em caso de dúvidas entre em contato com o nosso suporte.";
                modelErro.Titulo = "Ops! Página não encontrada.";
            }
            else if (id == 403)
            {
                modelErro.Mensagem =
                    "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso negado.";
            }
            else
            {
                return StatusCode(404);
            }

            modelErro.ErroCode = id;
            return View("Error", modelErro);
        }
    }
}

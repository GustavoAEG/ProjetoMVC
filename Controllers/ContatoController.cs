using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers;
public class ContatoController : Controller{

        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context){

            _context = context;
        }
public IActionResult Index()
{
    var contatos = _context.Contatos.ToList();
    return View(contatos);
}

//httpget opcional...
//chhama a pagina CRIAR CONTATO
//GET Quando entro na página
public ActionResult Criar(){

    return View();
}

//Post quando estou na pagina e envio informações pra salvar
[HttpPost]
public IActionResult Criar(Contato contato){

if(ModelState.IsValid){// se os dados estiverem validos
    
    _context.Contatos.Add(contato);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
}
return View(contato);
}

}
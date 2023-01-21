using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
 
    _context.Contatos.Add(contato);

    //using(AgendaContext agendaContext = new AgendaContext())
   // {
    // if(agendaContext.Contatos.Any(x => x.Nome == contato.Nome)){

    //     ViewBag.DuplicateMessage="Dp";
    // }
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
    
    return View(contato);
}

public IActionResult Editar(int id){

    var contato = _context.Contatos.Find(id);

    if(contato == null)

    return RedirectToAction(nameof(Index));

    return View(contato); //caso exista retorna os valores no campo
}

}
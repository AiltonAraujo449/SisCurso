using System;
using System.Collections.Generic;
using AutoMapper;
using DAO;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoDAO _contatoDAO;
        private readonly IMapper _mapper;
        private readonly ITelefoneDAO _telefoneDAO;

        public ContatoController(IContatoDAO contatoDAO, IMapper mapper, ITelefoneDAO telefoneDAO)
        {
            _contatoDAO = contatoDAO;
            _mapper = mapper;
            _telefoneDAO = telefoneDAO;
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Index()
        {            
            var lstContatoDTO = _contatoDAO.Consultar();
            var lstContatoViewModel = new List<ContatoViewModel>();

            foreach(var dto in lstContatoDTO)
            {
                lstContatoViewModel.Add(_mapper.Map<ContatoViewModel>(dto));                
            }
            return View(lstContatoViewModel);
        }
        
        [HttpPost]
        public IActionResult Create(ContatoViewModel contatoViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoViewModel);

            try
            {            
                _contatoDAO.Criar(contatoDTO);
                TempData[Constants.Message.SUCCESS] = "Contato incluído com sucesso.";
            }

            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Index");
        }
        
        public IActionResult Update(int id)
        {            
            var contatoDTO = _contatoDAO.Consultar(id);
            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO);            

            return View(contatoViewModel);
        }

        [HttpPost]
        public IActionResult Update(ContatoViewModel contatoViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoViewModel);
            try
            {            
                _contatoDAO.Atualizar(contatoDTO);
                TempData[Constants.Message.SUCCESS] = "Contato atualizado com sucesso.";
            }

            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {        
            try
            {    
                _contatoDAO.Excluir(id);
                TempData[Constants.Message.SUCCESS] = "Contato excluído com sucesso.";
            }
            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {            
            var contatoDTO = _contatoDAO.Consultar(id);

            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO); 

            var lstTelefoneDTO = _telefoneDAO.ConsultarPorContato(id);

            foreach(var telefoneDTO in lstTelefoneDTO)
            {
                contatoViewModel.LstTelefoneViewModel.Add(_mapper.Map<TelefoneViewModel>(telefoneDTO));
            }

            return View(contatoViewModel);
        }
    }
}
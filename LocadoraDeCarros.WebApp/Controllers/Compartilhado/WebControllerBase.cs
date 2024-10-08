﻿using System.Security.Claims;
using FluentResults;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers.Compartilhado
{
    public abstract class WebControllerBase : Controller
    {
        protected int? UsuarioId
        {
            get
            {
                var usuarioAutenticado = User.FindFirst(ClaimTypes.NameIdentifier);

                if (usuarioAutenticado is null)
                    return null;

                return int.Parse(usuarioAutenticado.Value);
            }
        }
        
        protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Erro",
                Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
            });

            return RedirectToAction("Index", "Inicio");
        }

        protected void ApresentarMensagemFalha(Result resultado)
        {
            ViewBag.Mensagem = new MensagemViewModel
            {
                Titulo = "Falha",
                Mensagem = resultado.Errors[0].Message
            };
        }
        
        protected void ApresentarMensagemSucesso(string mensagem)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Sucesso",
                Mensagem = mensagem
            });
        }
        
        protected void ApresentarMensagemInSucesso(string mensagem)
        {
            TempData.SerializarMensagemViewModel(new MensagemViewModel
            {
                Titulo = "Erro",
                Mensagem = mensagem
            });
        }
    }
}

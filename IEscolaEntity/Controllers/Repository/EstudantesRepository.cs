﻿using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using ServiceStack.OrmLite;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IEscolaEntity.Controllers.Repository
{
    public class EstudantesRepository : GenericRepository<Estudantes>, IEstudantes
    {
        public async Task<string> GetQR()
        {
            return await GetListaUnik();
        }
        private async Task<string> GetListaUnik()
        {
            var sql1 = DbConection.From<Estudantes>().OrderByDescending(x => x.EstudantesID);

            var result = await DbConection.SingleAsync<Estudantes>(sql1);

            if (result != null)
            {
                var fatura = result.Codigo;

                if (fatura != null)
                {
                    var tipo = fatura.Split(' ').FirstOrDefault();
                    var serie = fatura.Split(' ').LastOrDefault().Split('/').FirstOrDefault();
                    var numero = fatura.Split('/').LastOrDefault();

                    var serieFilterAno = Convert.ToInt32(serie.Substring(serie.Length - 4));

                    if (serieFilterAno == DateTime.Now.Year)
                    {
                        var numerosomado = Convert.ToInt32(numero) + 1;
                        var minhafatura = tipo + " " + serie + "/" + numerosomado;
                        return minhafatura;
                    }
                    else
                    {
                        var fatur = "QR " + "EST" + DateTime.Now.Year + "/" + 1;
                        return fatur;
                    }
                }
                else
                {
                    return "QR " + "EST" + DateTime.Now.Year + "/" + 1;
                }
            }
            else
            {
                var fatura = "QR " + "EST" + DateTime.Now.Year + "/" + 1;
                return fatura;
            }
        }

        public async Task<List<Estudantes>> GetAllinclud()
        {
            var sql = DbConection.From<Estudantes>();

            var result = await DbConection.LoadSelectAsync(sql);

            var classe = await DbConection.SelectAsync<Classes>();
            var periodo = await DbConection.SelectAsync<Periodos>();
            var curso = await DbConection.SelectAsync<Cursos>();
            var sala = await DbConection.SelectAsync<Salas>();

            var provincia = await DbConection.SelectAsync<Provincias>();
            var municipio = await DbConection.SelectAsync<Municipios>();
         
            result.ForEach(x =>
            {
                x.Turmas.Cursos = curso.Find(y => y.CursosID == x.Turmas.CursosID);
                x.Turmas.Classes = classe.Find(y => y.ClasseID == x.Turmas.ClassesID);
                x.Turmas.Periodos = periodo.Find(y => y.PeriodosID == x.Turmas.PeriodosID);
                x.Turmas.Salas = sala.Find(y => y.SalasID == x.Turmas.SalasID);


                x.Inscricoes.ProvinciasMunicipios.Provincias = provincia.Find(y => y.ProvinciasID == x.Inscricoes.ProvinciasMunicipios.ProvinciasID);
                x.Inscricoes.ProvinciasMunicipios.Municios = municipio.Find(y => y.ProvinciasID == x.Inscricoes.ProvinciasMunicipios.ProvinciasID);
            });
            return result;
        }
    }
}

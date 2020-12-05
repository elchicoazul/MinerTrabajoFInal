using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinerTrabajoFInal.Data;
using MinerTrabajoFInal.Models;

namespace MinerTrabajoFInal.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ILogger<ResultadoController> _logger;
        private readonly ApplicationDbContext _context;
        public ResultadoController(ILogger<ResultadoController> logger, ApplicationDbContext context)
        {
            _logger=logger;
            _context=context;
        }

        public IActionResult Index()
        {
            var resultado=_context.Resultado.ToList();
            return View(resultado);
        }
        [HttpPost]
        public IActionResult Buscar (Resultado objResultado)
        {
            if (ModelState.IsValid)
            {
                _context.search(objCliente);
                _context.SaveChanges();
                return RedirectToAction("Confirmacion");

            }
            return View("Crear", objCliente);
        }
 
    }

          

    public void busqueda(View view) {
        //String rpta; LISTO  PARA USAS  CON  LA  CLASE

        AdminSQLiteOpenHelper db = new AdminSQLiteOpenHelper(this, "SoyAdmin!", null, 1);
        SQLiteDatabase dbse = db.getWritableDatabase();
        String a1 = codi.getText().toString();
        if(!a1.isEmpty()){
          //  ClaseProducto pro = new ClaseProducto();
           // rpta=pro.select_cod(a1);
            Cursor fila = dbse.rawQuery("select * from productos where codigo ="+a1, null);
            if(fila.moveToFirst()){
                //db.execSQL("create table productos(codigo int  primary key , nombre text, categoria int, descripcion text, precio real,stock int)");
                codi.setText(fila.getString(0));
                Nom_pro.setText(fila.getString(1));
                cat.setText(fila.getString(2));
                descr.setText(fila.getString(3));
                price.setText(fila.getString(4));
                st.setText(fila.getString(5));}
            else{
                Toast.makeText(this, "Consulta  sin  resultados", Toast.LENGTH_SHORT).show();
            }
        } else {
            Toast.makeText(this, "Llenar Codigo", Toast.LENGTH_SHORT).show();
        }
    }
}
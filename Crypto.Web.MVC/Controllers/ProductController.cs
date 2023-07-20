using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.Web.MVC.Controllers
{
   
    public class ProductController : Controller
    {
        readonly IProductBL _productBL;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductBL productBL,IWebHostEnvironment webHostEnvironment)
        {
            _productBL = productBL;
            _webHostEnvironment = webHostEnvironment;

        }
        // GET: ProductController
        public async Task<IActionResult> Index(getProductsInputDTOs pProduct)
        {
            var list = await _productBL.Search(pProduct);
            return View(list);
        }


        // GET: ProductController/Details/5
        public  async  Task < ActionResult> Details(int id)
        {
            GetByIdProductOutputDTO Pproduct = await _productBL.GetById(id);
            return View(Pproduct);
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.ErrorMenssge = "";
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateProductInputDTOs pProduct)
        {
            try
            {
                CreateProductOutputDTOs result = await _productBL.Create(pProduct);

                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "No se pudo agregar el registro";
                    return View(pProduct);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
        //CONTINUACION 

        // GET: ProductController/Edit/5/Update 
        public async Task< ActionResult> Update(int Id)
        {
            GetByIdProductOutputDTO isProduct = await _productBL.GetById(Id);
            return View(isProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Update (UpdateProductInputDTOs pProduct)
        {
            try
            {
                UpdateProductOutputDTOs editProduct = await _productBL.Update(pProduct);
                if(editProduct != null){

                return RedirectToAction(nameof(Index));

                }else{

                    ViewBag.ErrorMessage = "Product not updated";
                    return View(pProduct);

                }
            }
            catch (Exception )
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int Id)
        {
            GetByIdProductOutputDTO isProduct = await _productBL.GetById(Id);
            return View(isProduct);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(DeleteProductsInputDTOs product)
        {
            try
            {
                DeleteProductsOutputDTOs pProduct = await _productBL.Delete(product);

                if(pProduct.IsDeleted ==true){

                  return RedirectToAction(nameof(Index));

                }else{
                    ViewBag.ErrorMessage = "Not eliminated product";
                    return View(product);
                    
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
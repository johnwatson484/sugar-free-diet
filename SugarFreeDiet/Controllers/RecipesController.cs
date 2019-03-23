using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SugarFreeDiet.DAL;
using SugarFreeDiet.Models;
using Microsoft.AspNet.Identity;
using SugarFreeDiet.Services;
using PagedList;

namespace SugarFreeDiet.Controllers
{
    public class RecipesController : Controller
    {
        SugarFreeDietContext db;
        IImageService imageService;

        public RecipesController()
        {
            db = new SugarFreeDietContext();
            imageService = new ImageService();
        }

        public RecipesController(SugarFreeDietContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }

        public ActionResult Index(int page = 1, int pageSize = 12)
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.Recipes.Include(r => r.User).OrderByDescending(x => x.Created).ToPagedList(page, pageSize));
            }
            else
            {
                return View(db.Recipes.Include(r => r.User).Where(x=>x.Active).OrderByDescending(x => x.Created).ToPagedList(page, pageSize));
            }
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "Created,Title,ShortDescription,Description,Ingredients,Directions,Servings,Hours,Minutes,Vegetarian,Vegan,Active")] Recipe recipe, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    recipe.Image = imageService.GetImageFromFile(file);
                    recipe.Thumbnail = imageService.GetThumbnail(recipe.Image);
                }

                recipe.SetCreated(User.Identity.GetUserId());
                db.Recipes.Add(recipe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "RecipeId,UserId,Created,Title,ShortDescription,Description,Ingredients,Directions,Servings,Hours,Minutes,Vegetarian,Vegan,Image,Thumbnail,Active")] Recipe recipe, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    recipe.Image = imageService.GetImageFromFile(file);
                    recipe.Thumbnail = imageService.GetThumbnail(recipe.Image);
                }

                db.Entry(recipe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = recipe.RecipeId });
            }
            return View(recipe);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            db.Recipes.Remove(recipe);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

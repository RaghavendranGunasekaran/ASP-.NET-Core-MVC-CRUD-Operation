using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTranscation.Models;

namespace BankTranscation.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionDBContext _context;

        public TransactionController(TransactionDBContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: Transaction/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactions = await _context.Transactions
        //        .FirstOrDefaultAsync(m => m.TransactionID == id);
        //    if (transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transactions);
        //}

        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            Transactions transactions = new Transactions();
            if (id == 0)
            {
               
                return View(transactions);
            }
            else
            {
                
                return View(_context.Transactions.Find(id));

            }
            
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionID,AccountNumber,BeneficiaryName,BankName,IFSCCode,Amount,Date")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {

                if (transactions.TransactionID == 0)
                {
                    transactions.Date = DateTime.Now;
                    _context.Add(transactions);
                }
                else
                {
                    _context.Update(transactions);
                }
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactions);
        }

        // GET: Transaction/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactions = await _context.Transactions.FindAsync(id);
        //    if (transactions == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(transactions);
        //}

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TransactionID,AccountNumber,BeneficiaryName,BankName,IFSCCode,Amount,Date")] Transactions transactions)
        //{
        //    if (id != transactions.TransactionID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(transactions);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TransactionsExists(transactions.TransactionID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(transactions);
        //}

        // GET: Transaction/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactions = await _context.Transactions
        //        .FirstOrDefaultAsync(m => m.TransactionID == id);
        //    if (transactions == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transactions);
        //}

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions != null)
            {
                _context.Transactions.Remove(transactions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool TransactionsExists(int id)
        //{
        //    return _context.Transactions.Any(e => e.TransactionID == id);
        //}
    }
}

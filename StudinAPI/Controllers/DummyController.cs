using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudinAPI.Model;

namespace StudinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly DBContext _context;

        public DummyController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Dummy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dummy>>> GetDummy()
        {
            return await _context.Dummy.ToListAsync();
        }

        // GET: api/Dummy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dummy>> GetDummy(int id)
        {
            var dummy = await _context.Dummy.FindAsync(id);

            if (dummy == null)
            {
                return NotFound();
            }

            return dummy;
        }

        // PUT: api/Dummy/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDummy(int id, Dummy dummy)
        {
            if (id != dummy.Id)
            {
                return BadRequest();
            }

            _context.Entry(dummy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DummyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dummy
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dummy>> PostDummy(Dummy dummy)
        {
            List<string> firstNames = new List<string>();
            firstNames.Add("Lars");
            firstNames.Add("Patrick");
            firstNames.Add("Caspar");
            firstNames.Add("Jamshid");
            firstNames.Add("Michael");
            firstNames.Add("Anders");
            firstNames.Add("Tim");
            firstNames.Add("Carl");
            firstNames.Add("Jonas");
            firstNames.Add("Jacob");

            List<string> lastNames = new List<string>();
            lastNames.Add("Selvik");
            lastNames.Add("Neilsen");
            lastNames.Add("Jensen");
            lastNames.Add("Hansen");
            lastNames.Add("Poulsen");
            lastNames.Add("Andersen");
            lastNames.Add("Larsen");
            lastNames.Add("Mikkelsen");
            lastNames.Add("Lauritz");
            lastNames.Add("Karlsen");
            lastNames.Add("Mortensen");

            List<string> userNamesPrefix = new List<string>();
            userNamesPrefix.Add("Pwnzor");
            userNamesPrefix.Add("username");
            userNamesPrefix.Add("DrAwesome");
            userNamesPrefix.Add("xX1337WaRRiORXx");
            userNamesPrefix.Add("BurningFlesh");
            userNamesPrefix.Add("Dezertor");
            userNamesPrefix.Add("IPlayTwitchAndFeed");
            userNamesPrefix.Add("DragonLord");
            userNamesPrefix.Add("IAmTheRealG");
            userNamesPrefix.Add("Owned");
            userNamesPrefix.Add("Roflcoptor");
            userNamesPrefix.Add("HelloKitty");
            userNamesPrefix.Add("TryingToLiveWithoutFear");
            userNamesPrefix.Add("IAmTheRealG");
            userNamesPrefix.Add("GreatSword");
            userNamesPrefix.Add("LongSword");
            userNamesPrefix.Add("CowKing");
            userNamesPrefix.Add("CowKilla");
            userNamesPrefix.Add("Lee");
            userNamesPrefix.Add("Alistar");
            userNamesPrefix.Add("Caitlyn");
            userNamesPrefix.Add("Warlord");
            userNamesPrefix.Add("BossMan");
            userNamesPrefix.Add("Teeto");
            userNamesPrefix.Add("Teemo");
            userNamesPrefix.Add("Taimo");
            userNamesPrefix.Add("Xerath");
            userNamesPrefix.Add("Lux");
            userNamesPrefix.Add("Morgana");
            userNamesPrefix.Add("Volibear");
            userNamesPrefix.Add("Udyr");
            userNamesPrefix.Add("Nagasaki");

            List<string> userNamesSalt = new List<string>();
            userNamesSalt.Add("1998");
            userNamesSalt.Add("123");
            userNamesSalt.Add("4300");
            userNamesSalt.Add("4000");
            userNamesSalt.Add("98");
            userNamesSalt.Add("97");
            userNamesSalt.Add("96");
            userNamesSalt.Add("85");
            userNamesSalt.Add("90");
            userNamesSalt.Add("89");
            userNamesSalt.Add("88");
            userNamesSalt.Add("2000");
            userNamesSalt.Add("87");
            userNamesSalt.Add("86");
            userNamesSalt.Add("OfDoom");
            userNamesSalt.Add("OfLust");
            userNamesSalt.Add("TheChickMagnet");
            userNamesSalt.Add("TheDaydreamer");
            userNamesSalt.Add("AloneWithMyself");
            userNamesSalt.Add("ForgottenYetNot");
            userNamesSalt.Add("OfTheForgotten");
            userNamesSalt.Add("Sin");
            userNamesSalt.Add("OfDestruction");
            userNamesSalt.Add("TheNiceLad");
            userNamesSalt.Add("OnlyFans");
            userNamesSalt.Add("TheFlamingo");
            userNamesSalt.Add("ScreamedTheStableBoy");
            userNamesSalt.Add("OfDoomLordMagnus");
            userNamesSalt.Add("ThatNeverSleeps");
            userNamesSalt.Add("WhoLovesCake");
            userNamesSalt.Add("OfTheMountain");
            userNamesSalt.Add("FromLondon");

            List<string> passwords = new List<string>();
            passwords.Add("password");
            passwords.Add("isthisit");
            passwords.Add("secret");
            passwords.Add("pass1234");

            List<string> salts = new List<string>();
            salts.Add("123");
            salts.Add("321");
            salts.Add("abc");
            salts.Add("lol");
            salts.Add("lal");


            List<string> emails = new List<string>();
            emails.Add("long@foryou.com");
            emails.Add("iamlegolas@hotmail.com");
            emails.Add("justme@gmail.com");
            emails.Add("whodisis@live.dk");

            List<int> phoneNumbers = new List<int>();
            phoneNumbers.Add(21122112);
            phoneNumbers.Add(11223344);
            phoneNumbers.Add(12345678);
            phoneNumbers.Add(11211211);
            phoneNumbers.Add(55667788);

            List<User> DummyUsers = new List<User>();

            for(int i = 0; i < dummy.Amount; i++)
            {
                Random r = new Random();
                string password = passwords[r.Next(passwords.Count())];
                string username;
                do { username = userNamesPrefix[r.Next(userNamesPrefix.Count())] + userNamesSalt[r.Next(userNamesSalt.Count())]; }
                while (DummyUsers.Exists(x => x.Username == username));

            }


            _context.Dummy.Add(dummy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDummy", new { id = dummy.Id }, dummy);

        }

        // DELETE: api/Dummy/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dummy>> DeleteDummy(int id)
        {
            var dummy = await _context.Dummy.FindAsync(id);
            if (dummy == null)
            {
                return NotFound();
            }

            _context.Dummy.Remove(dummy);
            await _context.SaveChangesAsync();

            return dummy;
        }

        private bool DummyExists(int id)
        {
            return _context.Dummy.Any(e => e.Id == id);
        }
    }
}

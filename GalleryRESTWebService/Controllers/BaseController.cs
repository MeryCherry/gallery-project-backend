using BusinessLayer.Configuration;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace GalleryRESTWebService.Controllers
{
    public class BaseController<TProvider,TBLL> : ControllerBase where TProvider : IBaseEntityDAL<TBLL>
                                                                 where TBLL: class
    {
        protected IOptions<AppSettingsModel> _settings;
        protected TProvider _provider;

        public BaseController(IOptions<AppSettingsModel> settings)
        {
            this._settings = settings;
            _provider = (TProvider)Activator.CreateInstance(typeof(TProvider), new object[] { _settings });

        }

        [HttpGet]
      // [ProducesResponseType(typeof(IEnumerable<TBLL>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var list = _provider.Select().Items.ToList();
            if (list == null || list.Count == 0)
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpGet("{id}")]
      //  [ProducesResponseType(typeof(TBLL), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var entity = _provider.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }


        [HttpPost]
       // [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] TBLL entity)
        {
            try
            {
                _provider.Add(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }


        [HttpPut("{id}")]
        // [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] TBLL entity)
        {
            try
            {
                _provider.Update(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                _provider.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

    }
}
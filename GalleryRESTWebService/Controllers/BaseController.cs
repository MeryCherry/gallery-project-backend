using BusinessLayer.AppEntities;
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
                                                                 where TBLL: class, IBaseEntity
    {
        protected IOptions<AppSettingsModel> _settings;
        protected IBaseEntityDAL<TBLL> _provider;

        public BaseController(IEntityDALFactory factory)
        {
            _provider = factory.Get<TProvider,TBLL>();

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
        [ProducesResponseType(typeof(UserEntity), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] TBLL entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _provider.Add(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtAction("Post", new { id = entity.Id }, entity);
        }


        [HttpPut("{id}")]
         [ProducesResponseType(typeof(UserEntity), StatusCodes.Status201Created)]
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
            return CreatedAtAction("Post", new { id = entity.Id }, entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var existingItem = _provider.Get(id);

            if (existingItem == null)
            {
                return NotFound();
            }
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
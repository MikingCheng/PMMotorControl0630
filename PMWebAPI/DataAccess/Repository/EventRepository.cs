using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMWebAPI.DataAccess.IRepository;
using PMWebAPI.DataAccess.model;
using PMWebAPI.PMDomain.EFContext;
using PMWebAPI.PMDomain.Entity; 

namespace PMWebAPI.DataAccess.Repository
{
    public class EventRepository: IEventRepository
    {
        private ShadingContext _context;

        #region constructor
        public EventRepository() { }

        public EventRepository(ShadingContext context)
        {
            this._context = context;
        }
        #endregion

        public void Add(MEvent mEvent)
        {
            _context.Events.Add(new Event
            {
                EventId = new Guid(),
                ProjectId = mEvent.ProjectId,
                LocationId = mEvent.LocationId,
                EventMessageId = this._context.EventMessages
                                     .Where(em => em.MessageCode == mEvent.MessageCode)
                                     .FirstOrDefault().EventMessageId,
                ModifiedDate = DateTime.Now
            });

            _context.SaveChanges();
        }

        public async Task<IEnumerable<MEvent>> GetAllAsync(Guid projectId)
        {
            var _event = await _context.Events
                                       .Where(e => e.ProjectId == projectId)
                                       .ToListAsync<Event>();
            var _evemtMessage = await _context.EventMessages.ToListAsync<EventMessage>();

            return _event.Select(e => new MEvent
                    {
                        LocationId = e.LocationId,
                        ProjectId = e.ProjectId,
                        MessageCode = _evemtMessage.Where(em => em.EventMessageId == e.EventMessageId)
                                                 .First<EventMessage>()
                                                 .MessageCode,
                        Comment = e.Comment
                    });
        }

        public async Task<IEnumerable<MEvent>> GetAllOfLocationAsync(Guid projectId, Guid locationId)
        {
            var _event = await _context.Events
                                       .Where(e => e.ProjectId == projectId && e.LocationId==locationId)
                                       .ToListAsync<Event>();
            var _evemtMessage = await _context.EventMessages.ToListAsync<EventMessage>();

            return _event.Select(e => new MEvent
            {
                LocationId = e.LocationId,
                ProjectId = e.ProjectId,
                MessageCode = _evemtMessage.Where(em => em.EventMessageId == e.EventMessageId)
                                                 .First<EventMessage>()
                                                 .MessageCode,
                Comment = e.Comment
            });
        }

        public async Task<IEnumerable<MEvent>> GetAllSpecifiedEventAsync(Guid projectId, int messageCode)
        {
            var _eventMessage = await _context.EventMessages
                                                .Where(em=>em.MessageCode==messageCode)
                                                .FirstAsync<EventMessage>();
            var _event = await _context.Events
                                       .Where(e => e.ProjectId == projectId && e.EventMessageId == _eventMessage.EventMessageId)
                                       .ToListAsync<Event>();

            return _event.Select(e => new MEvent
            {
                LocationId = e.LocationId,
                ProjectId = e.ProjectId,
                MessageCode = messageCode,
                Comment = e.Comment
            });
        }

    }
}

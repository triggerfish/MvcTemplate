using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Triggerfish.Database;
using Triggerfish.Linq;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class Genre : Entity<int>, IGenre
	{
		public virtual string Name { get; set; }

		public virtual IList<Artist> Artists  { get; set; }

		IEnumerable<IArtist> IGenre.Artists
		{
			get { return Artists.Cast<IArtist>(); }
		}

		public Genre()
		{
			Artists = new List<Artist>();
		}

		public virtual void AddArtist(Artist artist)
		{
			artist.Genre = this;
			Artists.Add(artist);
		}
	
		public virtual void AddArtists(IEnumerable<Artist> artists)
		{
			artists.ForEach(a => AddArtist(a));
		}
	}
}

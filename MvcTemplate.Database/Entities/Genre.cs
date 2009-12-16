using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcTemplate.Model;

namespace MvcTemplate.Database
{
	public class Genre : Entity<int>, IGenre
	{
		private IList<Artist> m_artists = new List<Artist>();

		public virtual string Name { get; set; }

		public virtual IList<Artist> Artists 
		{
			get { return m_artists; }
			set { m_artists = value; }
		}

		IEnumerable<IArtist> IGenre.Artists
		{
			get { return Artists.Cast<IArtist>(); }
		}

		public virtual void AddArtist(Artist a_artist)
		{
			a_artist.Genre = this;
			Artists.Add(a_artist);
		}
	
		public virtual void AddArtists(IEnumerable<Artist> a_artists)
		{
			a_artists.ForEach(a => AddArtist(a));
		}
	}
}

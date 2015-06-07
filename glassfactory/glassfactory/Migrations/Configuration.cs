using glassfactory.Models;

namespace glassfactory.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<glassfactory.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public DbSet<TextEntry> TextEntries { get; set; }

        protected override void Seed(glassfactory.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.TextEntries.AddOrUpdate(
                t => t.EntryName,
                new TextEntry() { AuthorName = "Gregory Kan", EntryBody = "He wanted what happened to be something he could know. As though knowing in just the right way would be enough to free him from pain. At the back of the room, the mirror, dreaming of becoming itself at last. He wanted what he knew to be something he could describe, to which others could say, I know this, this happened to me also. The bricks becoming birds. The leaves across his face. This hole inside belief. Not enough information survives to sustain judgment. Too much information survives to sustain judgment. He was told to fill all sinks, baths and buckets with water by three o’clock. He unscrewed the lights from the ceiling, one by one. Whose throat became birds. Whose hands were clenched, but filled with seas. When it seemed like everything would break into smaller rivers and streams. He signaled his intent, hoping that signaling would make it so. It hurt him to know that the full reach and depth of the sea were imperceptible to him. His secret ugliness was a stagnant lake under the forest. I’m amazed, he said, by the number of things I’ve held onto by trying to throw them away. He wanted fixed terms, so that he could say, when the whole forest was burning, I did the right thing. As though knowing that he had done the right thing would be enough to free him from pain. He let himself drift out beneath the water lilies. When cleaning the flat the things she frequented most ash hair rice urine skin. She took the bucket to where the dogs were tied up. The ways in which things that were, still are. She got permission from the teacher. She put on her hallway pass. She woke up in a small bedroom with a skylight. She went downstairs. This is not the place I started in, she said, although I’m not sure I would recognize that anyway. She woke up in the shed with her rifle. She remembers not being able to say a word. To know that she had mass, and impacted the bodies around her. She learnt to check ears eyes nose teeth and skin all over. A hammock in which her pulse rose and fell. All they took to the cabin were some stale bread, discarded books, a knife, a notebook, a map. A telescope through which they could see the rings of Saturn. They wandered in the forest all day, marking the trees with the knife so they knew where they’d been. They kept walking, as if they knew all the parts, and could play them, the doors between all the leaves on the ground. They carried each other across the fear, to disappear, to disappear and re-appear, in many places at once. The answers they carved from distance, which was no distance at all. The names they repeated in each other’s names, in the grass, forgetting what feet were.", EntryName = "doors between leaves" }
                );
        }
    }
}

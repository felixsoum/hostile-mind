using System;

namespace HostileMind
{
    public interface GameState
    {
        void Load();
        void Update();
        void Draw();
    }
}

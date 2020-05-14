using Game.Misc;

using UnityEngine;

namespace Game.Model
{
    public partial class ModelPacMan
    {
        class CmdMoveGhost : ICommand
        {
            eDirection _direction;
            eDirection _anotherDirection;

            bool isDangerous =true;
            bool isDangerousAnother = true;

            // ========================================

            public CmdMoveGhost()
            {
                _anotherDirection = eDirection.UP;  
            }

            // ============== ICommand ================

            void ICommand.Exec(IContextWritable context)
            {
                _direction = (eDirection)Random.Range(0, 4);
                _anotherDirection = (eDirection)Random.Range(0, 4);
                IGhostWritable ghost = context.CharactardsContainer.Get<IGhostWritable>();
                IGhostAnotherWritable ghostAnother = context.CharactardsContainer.Get<IGhostAnotherWritable>();
                IPacManWritable pacMan = context.CharactardsContainer.Get<IPacManWritable>();

                bool isCanMove = context.Field.IsCanMove(ghost.X, ghost.Y, _direction);




                // ========== cherry off =================
                if (Cherry.EnumCherry == eCherry.isInactive)
                {
                    if (Cherry.GhostisDead ==false)
                    {

                        if (ghost.X == pacMan.X && ghost.Y == pacMan.Y) context.EventManager.Get<IGhostEventsWritable>().PlayerDestroyed();
                    }

                    if (Cherry.GhostisDeadAnother == false)
                    {
                        if (ghostAnother.X == pacMan.X && ghostAnother.Y == pacMan.Y) context.EventManager.Get<IGhostEventsWritable>().PlayerDestroyed();
                    }

                        if (isCanMove)
                    {
                        (int x, int y) nextPositon = Direction.GetNextPosition(ghost.X, ghost.Y, _direction);

                        ghost.UpdatePosition(nextPositon.x, nextPositon.y);

                        context.EventManager.Get<IGhostEventsWritable>().UpdateGhostPosition(nextPositon.x, nextPositon.y);

                    }

                    if (pacMan.X - ghostAnother.X > 0)
                    {
                        _anotherDirection = eDirection.RIGHT;

                    }
                    else if (pacMan.X - ghostAnother.X < 0) _anotherDirection = eDirection.LEFT;

                    if (pacMan.Y - ghostAnother.Y > 0)
                    {
                        _anotherDirection = eDirection.UP;

                    }
                    else if (pacMan.X - ghostAnother.X == 0 && pacMan.Y - ghostAnother.Y < 0) _anotherDirection = eDirection.DOWN;

                    bool isCanMoveAnother = context.Field.IsCanMove(ghostAnother.X, ghostAnother.Y, _anotherDirection);
                    if (!isCanMoveAnother)
                    {
                        if (_anotherDirection == eDirection.DOWN || _anotherDirection == eDirection.UP)
                        {
                            if (pacMan.X - ghostAnother.X <= 0) _anotherDirection = eDirection.LEFT;
                            else _anotherDirection = eDirection.RIGHT;
                            isCanMoveAnother = context.Field.IsCanMove(ghostAnother.X, ghostAnother.Y, _anotherDirection);
                        }
                        else
                        {
                            if (pacMan.Y - ghostAnother.Y <= 0) _anotherDirection = eDirection.DOWN;
                            else _anotherDirection = eDirection.UP;
                            isCanMoveAnother = context.Field.IsCanMove(ghostAnother.X, ghostAnother.Y, _anotherDirection);

                        }
                    }

                    if (isCanMoveAnother)
                    {
                        (int x, int y) nextPositonAnother = Direction.GetNextPosition(ghostAnother.X, ghostAnother.Y, _anotherDirection);
                        ghostAnother.UpdatePosition(nextPositonAnother.x, nextPositonAnother.y);
                        context.EventManager.Get<IGhostEventsWritable>().UpdateGhostAnotherPosition(nextPositonAnother.x, nextPositonAnother.y);

                    }
                }

                // ========== cherry on =================
                else
                {
                    if (ghost.X == pacMan.X && ghost.Y == pacMan.Y) { context.EventManager.Get<IGhostEventsWritable>().GhostDestroyed(); Cherry.GhostisDead = true; }
                    if (ghostAnother.X == pacMan.X && ghostAnother.Y == pacMan.Y) { context.EventManager.Get<IGhostEventsWritable>().GhostAnootherDestroyed(); Cherry.GhostisDeadAnother = true; }
                   
                    if (pacMan.X - ghostAnother.X > 0)
                    {
                        _anotherDirection = eDirection.LEFT;

                    }
                    else if (pacMan.X - ghostAnother.X < 0) _anotherDirection = eDirection.RIGHT;

                    if (pacMan.Y - ghostAnother.Y > 0)
                    {
                        _anotherDirection = eDirection.DOWN;

                    }
                    else if (pacMan.X - ghostAnother.X == 0 && pacMan.Y - ghostAnother.Y < 0) _anotherDirection = eDirection.UP;

                    bool isCanMoveAnother = context.Field.IsCanMove(ghostAnother.X, ghostAnother.Y, _anotherDirection);
                    if (!isCanMoveAnother)
                    {
                        if (_anotherDirection == eDirection.DOWN || _anotherDirection == eDirection.UP)
                        {
                            if (pacMan.X - ghostAnother.X <= 0) _anotherDirection = eDirection.LEFT;
                            else _anotherDirection = eDirection.RIGHT;
                            isCanMoveAnother = context.Field.IsCanMove(ghostAnother.X, ghostAnother.Y, _anotherDirection);
                        }
                        else
                        {
                            if (pacMan.Y - ghostAnother.Y <= 0) _anotherDirection = eDirection.DOWN;
                            else _anotherDirection = eDirection.UP;
                            isCanMoveAnother = context.Field.IsCanMove(ghostAnother.X, ghostAnother.Y, _anotherDirection);

                        }
                    }

                    

                    if (pacMan.X - ghost.X > 0)
                    {
                        _direction = eDirection.LEFT;

                    }
                    else if (pacMan.X - ghost.X < 0) _direction = eDirection.RIGHT;

                    if (pacMan.Y - ghost.Y > 0)
                    {
                        _direction = eDirection.DOWN;

                    }
                    else if (pacMan.X - ghost.X == 0 && pacMan.Y - ghost.Y < 0) _direction = eDirection.UP;

                     isCanMove = context.Field.IsCanMove(ghost.X, ghost.Y, _direction);
                    if (!isCanMoveAnother)
                    {
                        if (_direction == eDirection.DOWN || _direction == eDirection.UP)
                        {
                            if (pacMan.X - ghost.X <= 0) _direction = eDirection.LEFT;
                            else _direction = eDirection.RIGHT;
                            isCanMoveAnother = context.Field.IsCanMove(ghost.X, ghost.Y, _direction);
                        }
                        else
                        {
                            if (pacMan.Y - ghost.Y <= 0) _anotherDirection = eDirection.DOWN;
                            else _anotherDirection = eDirection.UP;
                            isCanMoveAnother = context.Field.IsCanMove(ghost.X, ghost.Y, _direction);

                        }
                    }



                    if (isCanMove)
                    {

                        (int x, int y) nextPositon = Direction.GetNextPosition(ghost.X, ghost.Y, _direction);
                        ghost.UpdatePosition(nextPositon.x, nextPositon.y);
                        context.EventManager.Get<IGhostEventsWritable>().UpdateGhostPosition(nextPositon.x, nextPositon.y);
                    }


                        if (isCanMoveAnother)
                    {


                        (int x, int y) nextPositonAnother = Direction.GetNextPosition(ghostAnother.X, ghostAnother.Y, _anotherDirection);
                        ghostAnother.UpdatePosition(nextPositonAnother.x, nextPositonAnother.y);
                        context.EventManager.Get<IGhostEventsWritable>().UpdateGhostAnotherPosition(nextPositonAnother.x, nextPositonAnother.y);

                    }
                }
            }   
        }
    }
}
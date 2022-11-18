using System;

namespace EventsAndMulticastDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
           

            AudioSystem audioSystem = new AudioSystem();
            RenderingEngine renderingEngine = new RenderingEngine();

            Player player1 = new Player("SteelCow");
            Player player2 = new Player("DoggoSilva");
            Player player3 = new Player("DragonDog");

            GameEventManager.TriggerGameStart();
            GameEventManager.TriggerGameStart();


            /* 
             * * used in the first part before we code an event handler         
            audioSystem.StartGame();
            renderingEngine.StartGame();
            player1.StartGame();
            player2.StartGame();
            Console.WriteLine("Game is running. Press any key to end the game");
             Console.ReadKey();
            renderingEngine.GameOver();
            audioSystem.GameOver();
            player1.GameOver();
            player2.GameOver();
            */
            Console.WriteLine("Game is running. Press any key to end the game");

            Console.ReadKey();
            GameEventManager.TriggerGameOver();


            Console.WriteLine("Game is shutdown. Thank you for playing!");

        }
    }//Program

    class Player
    {
        public string PlayerName { get; set; }

        public Player(string name)
        {
            PlayerName = name;
            // In the current context += means subscribe. In other words it's like you are telling subscribe my method (the right operand) to this event (the left operand),
            // this way, when the event is raised, your method will be called.
            // Also, it is a good practice to unsubscribe (-= from this event, when you have finished your work ( but before you dispose you object )
            // in order to prevent your method being called and to prevent resource leaks. 
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;


        }

        private void StartGame()
        {
            Console.WriteLine($"Spawning player with ID {PlayerName}");
            GameEventManager.OnGameStart -= StartGame;
        }

        private void GameOver() {
            Console.WriteLine($"Removing player with ID {PlayerName}");
        }

    }//Player

    public class RenderingEngine
    {

        public RenderingEngine()
        {
            // In the current context += means subscribe. In other words it's like you are telling subscribe my method (the right operand) to this event (the left operand),
            // this way, when the event is raised, your method will be called.
            // Also, it is a good practice to unsubscribe (-= from this event, when you have finished your work ( but before you dispose you object )
            // in order to prevent your method being called and to prevent resource leaks. 
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;
        }

        private void StartGame()
        {
            Console.WriteLine("Rendering engine started...");
            Console.WriteLine("Drawing visuals...");
            GameEventManager.OnGameStart -= StartGame;

        }

        private void GameOver()
        {
            Console.WriteLine("Rendering Engine Stopped...");
        }
    }//RenderingEngine

    public class AudioSystem
    {
        
        public AudioSystem()
        {
            // In the current context += means subscribe. In other words it's like you are telling subscribe my method (the right operand) to this event (the left operand),
            // this way, when the event is raised, your method will be called.
            // Also, it is a good practice to unsubscribe (-= from this event, when you have finished your work ( but before you dispose you object )
            // in order to prevent your method being called and to prevent resource leaks. 
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameOver += GameOver;

        }
        
        private void StartGame()
        {
            Console.WriteLine("Audio system started...");
            Console.WriteLine("Playing Audio...");
            GameEventManager.OnGameStart -= StartGame;
        }

        private  void GameOver()
        {
            Console.WriteLine("Audio System Stopped...");
        }
    }//AudioSystem

    public class GameEventManager
    {
        //new delegate type called GameEvent
        public delegate void GameEvent();

        //create two delegates variables 
        public static event GameEvent OnGameStart, OnGameOver;

        public static void TriggerGameStart()
        {
            //check if the OnGameStart event is not empty
            //meaning that other methods are already subscribed to it

            if (OnGameStart != null)
            {
                Console.WriteLine("The game has started...");
                //call the OnGameStart that will trigger all the methods subscribed to this event
                OnGameStart();

            }
            else
            {
                Console.WriteLine("The game is ALREADY STARTED!");
            }

        }//TriggerGameStart()

        public static void TriggerGameOver()
        {

            if (OnGameOver != null)
            {
                Console.WriteLine("The game is ending...");
                //call the OnGameStart that will trigger all the methods subscribed to this event
                OnGameOver();

            }
            else
            {
                // this code never runs because nothing is unsubscribed
                Console.WriteLine("The game HAS ENDED!");
            }
        }


    }//GameEventManager


}

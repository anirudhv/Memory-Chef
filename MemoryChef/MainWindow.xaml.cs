using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PizzaMaker
{
    /// <summary>
    /// Written by Anirudh Venkataramanan
    /// </summary>

    public partial class Pizza : Window
    {
        Random rnd = new Random();
        private int numPepperoni = 0;
        private int numOlives = 0;
        private int numMushrooms = 0;
        private int numOnions = 0;
        private int userPepperoni = 0;
        private int userOlives = 0;
        private int userMushrooms = 0;
        private int userOnions = 0;
        private int userDough = 0;
        private int userSauce = 0;
        private int userCheese = 0;
        private int dough = 0;
        private int sauce = 0;
        private int cheese = 0;
        private int time = 45;
        private int bake = 11;
        private DispatcherTimer Timer;


        public Pizza()
        {
            InitializeComponent();
            order.Visibility = Visibility.Hidden;
            countertop.Visibility = Visibility.Hidden;
            gluten.Visibility = Visibility.Hidden;
            wheat.Visibility = Visibility.Hidden;
            wheatrolled.Visibility = Visibility.Hidden;
            glutenrolled.Visibility = Visibility.Hidden;
            tomatosauce.Visibility = Visibility.Hidden;
            pestosauce.Visibility = Visibility.Hidden;
            pestospread.Visibility = Visibility.Hidden;
            tomatospread.Visibility = Visibility.Hidden;
            mozz.Visibility = Visibility.Hidden;
            cheddar.Visibility = Visibility.Hidden;
            mozzspread.Visibility = Visibility.Hidden;
            cheddarspread.Visibility = Visibility.Hidden;
            onionbowl.Visibility = Visibility.Hidden;
            olivebowl.Visibility = Visibility.Hidden;
            mushroombowl.Visibility = Visibility.Hidden;
            ronibowl.Visibility = Visibility.Hidden;
            done.Visibility = Visibility.Hidden;
            olive1.Visibility = Visibility.Hidden;
            olive2.Visibility = Visibility.Hidden;
            olive3.Visibility = Visibility.Hidden;
            olive4.Visibility = Visibility.Hidden;
            olive5.Visibility = Visibility.Hidden;
            mushroom1.Visibility = Visibility.Hidden;
            mushroom2.Visibility = Visibility.Hidden;
            mushroom3.Visibility = Visibility.Hidden;
            mushroom4.Visibility = Visibility.Hidden;
            mushroom5.Visibility = Visibility.Hidden;
            onion1.Visibility = Visibility.Hidden;
            onion2.Visibility = Visibility.Hidden;
            onion3.Visibility = Visibility.Hidden;
            onion4.Visibility = Visibility.Hidden;
            onion5.Visibility = Visibility.Hidden;
            roni1.Visibility = Visibility.Hidden;
            roni2.Visibility = Visibility.Hidden;
            roni3.Visibility = Visibility.Hidden;
            roni4.Visibility = Visibility.Hidden;
            roni5.Visibility = Visibility.Hidden;
            errorMsg.Visibility = Visibility.Hidden;
            cheeseMsg.Visibility = Visibility.Hidden;
            doughMsg.Visibility = Visibility.Hidden;
            sauceMsg.Visibility = Visibility.Hidden;
            topMsg.Visibility = Visibility.Hidden;
            baker.Visibility = Visibility.Hidden;
            bakeMsg.Visibility = Visibility.Hidden;
            doughcheck.Visibility = Visibility.Hidden;
            doughx.Visibility = Visibility.Hidden;
            saucecheck.Visibility = Visibility.Hidden;
            saucex.Visibility = Visibility.Hidden;
            cheesecheck.Visibility = Visibility.Hidden;
            cheesex.Visibility = Visibility.Hidden;
            olivecheck.Visibility = Visibility.Hidden;
            olivex.Visibility = Visibility.Hidden;
            mushroomcheck.Visibility = Visibility.Hidden;
            mushroomx.Visibility = Visibility.Hidden;
            onioncheck.Visibility = Visibility.Hidden;
            onionx.Visibility = Visibility.Hidden;
            ronicheck.Visibility = Visibility.Hidden;
            ronix.Visibility = Visibility.Hidden;
            star1.Visibility = Visibility.Hidden;
            star2.Visibility = Visibility.Hidden;
            star3.Visibility = Visibility.Hidden;
            score.Visibility = Visibility.Hidden;
            again.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Visible;
         
        }

        private void playNow(object sender, System.EventArgs e)
        {
            Random rand = new Random();
            numPepperoni = rand.Next(0, 6);
            numOlives = rand.Next(0, 6);
            numMushrooms = rand.Next(0, 6);
            numOnions = rand.Next(0, 6);
            dough = rand.Next(1, 3);
            cheese = rand.Next(1, 3);
            sauce = rand.Next(1, 3);
            userMushrooms = 0;
            userOlives = 0;
            userOnions = 0;
            userPepperoni = 0;
            userDough = 0;
            userSauce = 0;
            userCheese = 0;
            time = 45;
            bake = 11;
            mushroomNum.Visibility = Visibility.Visible;
            onionNum.Visibility = Visibility.Visible;
            pepperoniNum.Visibility = Visibility.Visible;
            doughType.Visibility = Visibility.Visible;
            sauceType.Visibility = Visibility.Visible;
            cheeseType.Visibility = Visibility.Visible;
            oliveNum.Visibility = Visibility.Visible;
            memorize.Visibility = Visibility.Visible;
            msg1.Visibility = Visibility.Visible;
            pepperoniNum.Text = "x" + numPepperoni.ToString();
            oliveNum.Text = "x" + numOlives.ToString();
            mushroomNum.Text = "x" + numMushrooms.ToString();
            onionNum.Text = "x" + numOnions.ToString();
            if(dough == 1)
            {
                doughType.Text = "Wheat";
            }
            else
            {
                doughType.Text = "Gluten Free";
            }
            if(cheese == 1)
            {
                cheeseType.Text = "Mozzerella";
            }
            else
            {
                cheeseType.Text = "Cheddar";
            }
            if(sauce == 1)
            {
                sauceType.Text = "Tomato Sauce";
            }
            else
            {
                sauceType.Text = "Pesto Sauce";
            }
            msg1.Text = "Memorize the order before the timer runs out!";
            start.Visibility = Visibility.Hidden;
            order.Visibility = Visibility.Visible;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(time > 0)
            {
                time--;
                memorize.Text = string.Format("{1}", time / 60, time % 60);
            }
            else
            {
                Timer.Stop();
                memorize.Visibility = Visibility.Hidden;
                order.Visibility = Visibility.Hidden;
                mushroomNum.Visibility = Visibility.Hidden;
                oliveNum.Visibility = Visibility.Hidden;
                doughType.Visibility = Visibility.Hidden;
                cheeseType.Visibility = Visibility.Hidden;
                sauceType.Visibility = Visibility.Hidden;
                pepperoniNum.Visibility = Visibility.Hidden;
                msg1.Visibility = Visibility.Hidden;
                onionNum.Visibility = Visibility.Hidden;
                countertop.Visibility = Visibility.Visible;
                gluten.Visibility = Visibility.Visible;
                wheat.Visibility = Visibility.Visible;
                doughMsg.Visibility = Visibility.Visible;
                doughMsg.Text = "Select the dough for the pizza";
            }
        }
        private void DoughSelect(object sender, System.EventArgs e)
        {
            Image img = sender as Image;
            string s = img.Name.ToString();
            if(s == "wheat")
            {
                userDough = 1;
                //make the rolled out wheat dough visible, keep gluten dough hidden
                wheatrolled.Visibility = Visibility.Visible;
            }
            else
            {
                userDough = 2;
                glutenrolled.Visibility = Visibility.Visible;
            }
            wheat.Visibility = Visibility.Hidden;
            gluten.Visibility = Visibility.Hidden;
            doughMsg.Visibility = Visibility.Hidden;
            tomatosauce.Visibility = Visibility.Visible;
            pestosauce.Visibility = Visibility.Visible;
            sauceMsg.Visibility = Visibility.Visible;
            sauceMsg.Text = "Select a sauce to add \n to the pizza";
        }

        private void SauceSelect(object sender, System.EventArgs e)
        {
            Image img = sender as Image;
            string s = img.Name.ToString();
            if(s == "tomatosauce")
            {
                userSauce = 1;
                tomatospread.Visibility = Visibility.Visible;
            }
            else
            {
                userSauce = 2;
                pestospread.Visibility = Visibility.Visible;
            }
            tomatosauce.Visibility = Visibility.Hidden;
            pestosauce.Visibility = Visibility.Hidden;
            sauceMsg.Visibility = Visibility.Hidden;
            cheddar.Visibility = Visibility.Visible;
            mozz.Visibility = Visibility.Visible;
            cheeseMsg.Visibility = Visibility.Visible;
            cheeseMsg.Text = "Select a cheese to add \n to the pizza. Cheddar is \n orange while mozzerella \n is white.";
        }
        private void cheeseSelect(object sender, System.EventArgs e)
        {
            Image img = sender as Image;
            string s = img.Name.ToString();
            if(s == "mozz")
            {
                userCheese = 1;
                mozzspread.Visibility = Visibility.Visible;
            }
            else
            {
                userCheese = 2;
                cheddarspread.Visibility = Visibility.Visible;
            }
            cheddar.Visibility = Visibility.Hidden;
            mozz.Visibility = Visibility.Hidden;
            cheeseMsg.Visibility = Visibility.Hidden;
            olivebowl.Visibility = Visibility.Visible;
            mushroombowl.Visibility = Visibility.Visible;
            ronibowl.Visibility = Visibility.Visible;
            onionbowl.Visibility = Visibility.Visible;
            done.Visibility = Visibility.Visible;
            topMsg.Visibility = Visibility.Visible;
            topMsg.Text = "Click on a topping to add it to the pizza. Click 'DONE' when you are done.";
        }
        private void topSelect(object sender, System.EventArgs e)
        {
            Image img = sender as Image;
            string s = img.Name.ToString();
            errorMsg.Visibility = Visibility.Hidden;
            errorMsg.Text = "";
            if(s == "olivebowl")
            {
                if(userOlives < 5)
                {
                    userOlives++;
                }
                else
                {
                    errorMsg.Visibility = Visibility.Visible;
                    errorMsg.Text = "You have added the maximum amount of olives.";
                }
                if(userOlives == 1)
                {
                    olive1.Visibility = Visibility.Visible;
                }
                if(userOlives == 2)
                {
                    olive2.Visibility = Visibility.Visible;
                }
                if(userOlives == 3)
                {
                    olive3.Visibility = Visibility.Visible;
                }
                if(userOlives == 4)
                {
                    olive4.Visibility = Visibility.Visible;
                }
                if(userOlives == 5)
                {
                    olive5.Visibility = Visibility.Visible;
                }

            }
            if(s == "mushroombowl")
            {
                if (userMushrooms < 5)
                {
                    userMushrooms++;
                }
                else
                {
                    errorMsg.Visibility = Visibility.Visible;
                    errorMsg.Text = "You have added the maximum amount of mushrooms.";
                }
                if (userMushrooms == 1)
                {
                    mushroom1.Visibility = Visibility.Visible;
                }
                if (userMushrooms == 2)
                {
                    mushroom2.Visibility = Visibility.Visible;
                }
                if (userMushrooms == 3)
                {
                    mushroom3.Visibility = Visibility.Visible;
                }
                if (userMushrooms == 4)
                {
                    mushroom4.Visibility = Visibility.Visible;
                }
                if (userMushrooms == 5)
                {
                    mushroom5.Visibility = Visibility.Visible;
                }
            }
            if(s == "onionbowl")
            {
                if (userOnions < 5)
                {
                    userOnions++;
                }
                else
                {
                    errorMsg.Visibility = Visibility.Visible;
                    errorMsg.Text = "You have added the maximum amount of onions.";
                }
                if (userOnions == 1)
                {
                    onion1.Visibility = Visibility.Visible;
                }
                if (userOnions == 2)
                {
                    onion2.Visibility = Visibility.Visible;
                }
                if (userOnions == 3)
                {
                    onion3.Visibility = Visibility.Visible;
                }
                if (userOnions == 4)
                {
                    onion4.Visibility = Visibility.Visible;
                }
                if (userOnions == 5)
                {
                    onion5.Visibility = Visibility.Visible;
                }
            }
            if(s == "ronibowl")
            {
                if (userPepperoni < 5)
                {
                    userPepperoni++;
                }
                else
                {
                    errorMsg.Visibility = Visibility.Visible;
                    errorMsg.Text = "You have added the maximum amount of pepperonis.";
                }
                if (userPepperoni == 1)
                {
                    roni1.Visibility = Visibility.Visible;
                }
                if (userPepperoni == 2)
                {
                    roni2.Visibility = Visibility.Visible;
                }
                if (userPepperoni == 3)
                {
                    roni3.Visibility = Visibility.Visible;
                }
                if (userPepperoni == 4)
                {
                    roni4.Visibility = Visibility.Visible;
                }
                if (userPepperoni == 5)
                {
                    roni5.Visibility = Visibility.Visible;
                }
            }
        }
        private void cook(object sender, System.EventArgs e)
        {
            errorMsg.Visibility = Visibility.Hidden;
            topMsg.Visibility = Visibility.Hidden;
            done.Visibility = Visibility.Hidden;
            olivebowl.Visibility = Visibility.Hidden;
            mushroombowl.Visibility = Visibility.Hidden;
            onionbowl.Visibility = Visibility.Hidden;
            ronibowl.Visibility = Visibility.Hidden;
            baker.Visibility = Visibility.Visible;
            bakeMsg.Visibility = Visibility.Visible;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tock;
            Timer.Start();

        }
        private void Timer_Tock(object sender, EventArgs e)
        {
           
            if (bake > 0)
            {
                bake--;
                bakeMsg.Text = string.Format("The pizza will finish baking in {1} seconds", bake / 60, bake % 60);
            }
            else
            {
                Timer.Stop();
                bakeMsg.Visibility = Visibility.Hidden;
                baker.Visibility = Visibility.Hidden;
                countertop.Visibility = Visibility.Hidden;
                gluten.Visibility = Visibility.Hidden;
                wheat.Visibility = Visibility.Hidden;
                wheatrolled.Visibility = Visibility.Hidden;
                glutenrolled.Visibility = Visibility.Hidden;
                tomatosauce.Visibility = Visibility.Hidden;
                pestosauce.Visibility = Visibility.Hidden;
                pestospread.Visibility = Visibility.Hidden;
                tomatospread.Visibility = Visibility.Hidden;
                mozz.Visibility = Visibility.Hidden;
                cheddar.Visibility = Visibility.Hidden;
                mozzspread.Visibility = Visibility.Hidden;
                cheddarspread.Visibility = Visibility.Hidden;
                onionbowl.Visibility = Visibility.Hidden;
                olivebowl.Visibility = Visibility.Hidden;
                mushroombowl.Visibility = Visibility.Hidden;
                ronibowl.Visibility = Visibility.Hidden;
                done.Visibility = Visibility.Hidden;
                olive1.Visibility = Visibility.Hidden;
                olive2.Visibility = Visibility.Hidden;
                olive3.Visibility = Visibility.Hidden;
                olive4.Visibility = Visibility.Hidden;
                olive5.Visibility = Visibility.Hidden;
                mushroom1.Visibility = Visibility.Hidden;
                mushroom2.Visibility = Visibility.Hidden;
                mushroom3.Visibility = Visibility.Hidden;
                mushroom4.Visibility = Visibility.Hidden;
                mushroom5.Visibility = Visibility.Hidden;
                onion1.Visibility = Visibility.Hidden;
                onion2.Visibility = Visibility.Hidden;
                onion3.Visibility = Visibility.Hidden;
                onion4.Visibility = Visibility.Hidden;
                onion5.Visibility = Visibility.Hidden;
                roni1.Visibility = Visibility.Hidden;
                roni2.Visibility = Visibility.Hidden;
                roni3.Visibility = Visibility.Hidden;
                roni4.Visibility = Visibility.Hidden;
                roni5.Visibility = Visibility.Hidden;
                errorMsg.Visibility = Visibility.Hidden;
                cheeseMsg.Visibility = Visibility.Hidden;
                doughMsg.Visibility = Visibility.Hidden;
                sauceMsg.Visibility = Visibility.Hidden;
                topMsg.Visibility = Visibility.Hidden;
                oliveNum.Visibility = Visibility.Visible;
                doughType.Visibility = Visibility.Visible;
                mushroomNum.Visibility = Visibility.Visible;
                onionNum.Visibility = Visibility.Visible;
                pepperoniNum.Visibility = Visibility.Visible;
                cheeseType.Visibility = Visibility.Visible;
                sauceType.Visibility = Visibility.Visible;
                order.Visibility = Visibility.Visible;
                grading();

            }
        }
        private void grading()
        {
            double grade = 0; 
            if(userMushrooms == numMushrooms)
            {
                grade++;
                mushroomcheck.Visibility = Visibility.Visible;

            }
            else
            {
                int diff = Math.Abs(userMushrooms - numMushrooms);
                grade += 1 - (0.2 * diff);
                mushroomx.Visibility = Visibility.Visible;
            }
            if(userOlives == numOlives)
            {
                olivecheck.Visibility = Visibility.Visible;
                grade++;
            }
            else
            {
                int diff = Math.Abs(userOlives - numOlives);
                grade += 1 - (0.2 * diff);
                olivex.Visibility = Visibility.Visible;
            }
            if(userPepperoni == numPepperoni)
            {
                grade++;
                ronicheck.Visibility = Visibility.Visible;
            }
            else
            {
                int diff = Math.Abs(userPepperoni - numPepperoni);
                grade += 1 - (0.2 * diff);
                ronix.Visibility = Visibility.Visible;
            }
            if(userOnions == numOnions)
            {
                grade++;
                onioncheck.Visibility = Visibility.Visible;
            }
            else
            {
                int diff = Math.Abs(userPepperoni - numPepperoni);
                grade += 1 - (0.2 * diff);
                onionx.Visibility = Visibility.Visible;
            }
            if (userDough == dough)
            {
                grade++;
                doughcheck.Visibility = Visibility.Visible;
            }
            else
            {
                doughx.Visibility = Visibility.Visible;
            }
            if(userSauce == sauce)
            {
                grade++;
                saucecheck.Visibility = Visibility.Visible;
            }
            else
            {
                saucex.Visibility = Visibility.Visible;
            }
            if(userCheese == cheese)
            {
                grade++;
                cheesecheck.Visibility = Visibility.Visible;
            }
            else
            {
                cheesex.Visibility = Visibility.Visible;
            }
            if(grade / 7 >= 0.33)
            {
                star1.Visibility = Visibility.Visible;
            }
            if(grade / 7 >= 0.66)
            {
                star2.Visibility = Visibility.Visible;
            }
            if(grade / 7 == 1)
            {
                star3.Visibility = Visibility.Visible;
            }
            score.Visibility = Visibility.Visible;
            score.Text = "Your final score is: " + Math.Round(grade / 7 * 100, 2) + "%";
            again.Visibility = Visibility.Visible;
        }
        private void playAgain(object sender, System.EventArgs e)
        {
            order.Visibility = Visibility.Hidden;
            countertop.Visibility = Visibility.Hidden;
            gluten.Visibility = Visibility.Hidden;
            wheat.Visibility = Visibility.Hidden;
            wheatrolled.Visibility = Visibility.Hidden;
            glutenrolled.Visibility = Visibility.Hidden;
            tomatosauce.Visibility = Visibility.Hidden;
            pestosauce.Visibility = Visibility.Hidden;
            pestospread.Visibility = Visibility.Hidden;
            tomatospread.Visibility = Visibility.Hidden;
            mozz.Visibility = Visibility.Hidden;
            cheddar.Visibility = Visibility.Hidden;
            mozzspread.Visibility = Visibility.Hidden;
            cheddarspread.Visibility = Visibility.Hidden;
            onionbowl.Visibility = Visibility.Hidden;
            olivebowl.Visibility = Visibility.Hidden;
            mushroombowl.Visibility = Visibility.Hidden;
            ronibowl.Visibility = Visibility.Hidden;
            done.Visibility = Visibility.Hidden;
            olive1.Visibility = Visibility.Hidden;
            olive2.Visibility = Visibility.Hidden;
            olive3.Visibility = Visibility.Hidden;
            olive4.Visibility = Visibility.Hidden;
            olive5.Visibility = Visibility.Hidden;
            mushroom1.Visibility = Visibility.Hidden;
            mushroom2.Visibility = Visibility.Hidden;
            mushroom3.Visibility = Visibility.Hidden;
            mushroom4.Visibility = Visibility.Hidden;
            mushroom5.Visibility = Visibility.Hidden;
            onion1.Visibility = Visibility.Hidden;
            onion2.Visibility = Visibility.Hidden;
            onion3.Visibility = Visibility.Hidden;
            onion4.Visibility = Visibility.Hidden;
            onion5.Visibility = Visibility.Hidden;
            roni1.Visibility = Visibility.Hidden;
            roni2.Visibility = Visibility.Hidden;
            roni3.Visibility = Visibility.Hidden;
            roni4.Visibility = Visibility.Hidden;
            roni5.Visibility = Visibility.Hidden;
            errorMsg.Visibility = Visibility.Hidden;
            cheeseMsg.Visibility = Visibility.Hidden;
            doughMsg.Visibility = Visibility.Hidden;
            sauceMsg.Visibility = Visibility.Hidden;
            topMsg.Visibility = Visibility.Hidden;
            baker.Visibility = Visibility.Hidden;
            bakeMsg.Visibility = Visibility.Hidden;
            doughcheck.Visibility = Visibility.Hidden;
            doughx.Visibility = Visibility.Hidden;
            saucecheck.Visibility = Visibility.Hidden;
            saucex.Visibility = Visibility.Hidden;
            cheesecheck.Visibility = Visibility.Hidden;
            cheesex.Visibility = Visibility.Hidden;
            olivecheck.Visibility = Visibility.Hidden;
            olivex.Visibility = Visibility.Hidden;
            mushroomcheck.Visibility = Visibility.Hidden;
            mushroomx.Visibility = Visibility.Hidden;
            onioncheck.Visibility = Visibility.Hidden;
            onionx.Visibility = Visibility.Hidden;
            ronicheck.Visibility = Visibility.Hidden;
            ronix.Visibility = Visibility.Hidden;
            star1.Visibility = Visibility.Hidden;
            star2.Visibility = Visibility.Hidden;
            star3.Visibility = Visibility.Hidden;
            score.Visibility = Visibility.Hidden;
            again.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Visible;
            oliveNum.Visibility = Visibility.Hidden;
            mushroomNum.Visibility = Visibility.Hidden;
            onionNum.Visibility = Visibility.Hidden;
            pepperoniNum.Visibility = Visibility.Hidden;
            doughType.Visibility = Visibility.Hidden;
            sauceType.Visibility = Visibility.Hidden;
            cheeseType.Visibility = Visibility.Hidden;
        }
    }
}

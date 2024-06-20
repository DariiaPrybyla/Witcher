using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Witcher
{
    public partial class background : Form
    {
        int story = 0; //Змінна, яка відстежує поточний крок в історії гри.
        private Timer heraldAttackTimer = new Timer(); // Таймер, який використовується для контролю атаки Геральда у бою.
        private Timer enemyAttackTimer = new Timer(); // Таймер, який використовується для контролю атаки ворога у бою.
        private Random random = new Random(); // Генератор випадкових чисел, використовується для визначення урону від ворога.
        private bool isHeraldTurn = true; // Вибір ходу: true - хід Геральда, false - хід ворога.
        private bool isBattleInProgress = false; // Змінна стану, що вказує, чи зараз ведеться бій.
        private bool isBattleFinished = false; // Змінна стану, що вказує, на завершення бою.
        private bool thunderUsed = false; // Булева змінна для відстеження використання відповідних навички thunder у бою.
        private bool martinUsed = false; // Булева змінна для відстеження використання відповідних навички martin у бою.
        private bool quenUsed = false; // Булева змінна для відстеження використання відповідних навички quen у бою.
        private bool quenActive = false; // Булева змінна, яка вказує, чи активний ефект quen.
        private bool enemyRobber = true; // Змінна, яка визначає тип ворога: true - robber, а false - not robber
        private bool enemyPeasant = true; // Змінна, яка визначає тип ворога: true - peasant, а false - not peasant
        List<string> robberPhrases = new List<string> // Фрази ворога robber
        {
            "Розбійник: Колдун їбучий!",
            "Розбійник: Мутант!"
        };
        List<string> peasantPhrases = new List<string> // Фрази ворога peasant
        {
            "Селянин: Колдун їбучий!",
            "Селянин: Мутант!"
        };
        List<string> geraltPhrases = new List<string> // Фрази Геральда
        {
            "Геральд: Зараза!",
            "Геральд: Це все, що ти можеш?",
            "Геральд: Ах, ти курва!"
        };

        public background()
        {
            InitializeComponent();

            //Блокування усіх елементи, окрім кнопки
            foreach (Control control in this.Controls)
            {
                if (control != start)
                {
                    control.Enabled = false;
                }
            }

            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Center;
            title.Image = Properties.Resources.title;
            start.Image = Properties.Resources.start;

            character.Visible = false;
            text_history.Visible = false;
            health_Herald.Visible = false;
            health_enemy.Visible = false;
            kill_Herald.Visible = false;
            kill_Enemy.Visible = false;
            thunder.Visible = false;
            martin.Visible = false;
            quen.Visible = false;
            igni.Visible = false;
            quen_indicator.Visible = false;

            health_Herald.Value = 100;
            health_enemy.Value = 100;

            // Настройка таймеру для Геральда
            heraldAttackTimer.Interval = 1000; // Інтервал у мілісекундах (1 секунда)
            heraldAttackTimer.Tick += (s, e) => HeraldAttack(); // Обробник атаки Геральда

            // Настройка таймеру для ворога
            enemyAttackTimer.Interval = 1000;
            enemyAttackTimer.Tick += (s, e) => EnemyAttack(); // Обробник атаки ворога
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (story == 0)
            {
                // Розблокування усіх елементів
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }

                BackgroundImage = Properties.Resources.chapter_0;
                BackgroundImageLayout = ImageLayout.Zoom;
                title.Visible = false;
                start.Visible = false;
                text_history.Visible = true;
                text_history.Text = "Ви починаєте гру у ролі Геральда, який подорожує до селища, вказаного в завданні.\nВаш шлях перегороджують розбійники.";
                text_history.Font = new Font("Segoe Script", 12, FontStyle.Bold);
                text_history.ForeColor = Color.White;
                text_history.TextAlign = ContentAlignment.MiddleCenter;

                story++;
            }
        }

        private void background_Click(object sender, EventArgs e)
        {
            // Пролог
            if (story == 1)
            {
                character.Visible = true;

                BackgroundImage = Properties.Resources.chapter_0_dark;
                character.BackgroundImage = Properties.Resources.robber;
                character.BackgroundImageLayout = ImageLayout.Zoom;
                text_history.Text = "Розбійник: Стій, мутант! Ти потрапив на нашу територію.\nВіддай гроші та йди далі без проблем.";

                story++;
            }
            else if (story == 2)
            {
                BackgroundImage = Properties.Resources.chapter_0;
                character.Visible = false;
                text_history.Text = "Геральд намагався піти без бою, але розбійники не відставали.";

                story++;
            }
            else if (story == 3)
            {
                BackgroundImage = Properties.Resources.chapter_0_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald_plotva;
                text_history.Text = "Геральд: Чому так завжди відбувається? Добре, з'ясуємо це в бою!";

                story++;
            }
            else if (story == 4)
            {
                health_Herald.Value = 100;
                health_enemy.Value = 100;

                enemyRobber = true;
                enemyPeasant = false;
                character.Visible = false;
                health_Herald.Visible = true;
                health_enemy.Visible = true;
                thunder.Visible = true;
                martin.Visible = true;
                quen.Visible = true;
                igni.Visible = true;
                kill_Herald.Visible = true;
                kill_Enemy.Visible = true;
                kill_Herald.BackgroundImage = Properties.Resources.herald_kill;
                kill_Enemy.BackgroundImage = Properties.Resources.robber;
                thunder.BackgroundImage = Properties.Resources.thunder;
                martin.BackgroundImage = Properties.Resources.martin;
                quen.BackgroundImage = Properties.Resources.quen;
                igni.BackgroundImage = Properties.Resources.igni;
                kill_Herald.BackgroundImageLayout = ImageLayout.Zoom;
                kill_Enemy.BackgroundImageLayout = ImageLayout.Zoom;
                thunder.BackgroundImageLayout = ImageLayout.Zoom;
                martin.BackgroundImageLayout = ImageLayout.Zoom;
                quen.BackgroundImageLayout = ImageLayout.Zoom;
                igni.BackgroundImageLayout = ImageLayout.Zoom;
                text_history.Text = "!!! БІЙ !!!";

                isBattleInProgress = true; // Встановлюємо стан бою
                kill_Enemy.Enabled = true; // Активуємо елемент
            }
            else if (story == 5)
            {
                BackgroundImage = Properties.Resources.chapter_0;
                text_history.Text = "Ви починаєте гру у ролі Геральда, який подорожує до селища, вказаного в завданні.\nВаш шлях перегороджують розбійники.";


                story = 1;
            }
            else if (story == 6)
            {
                BackgroundImage = Properties.Resources.chapter_0;
                text_history.Text = "Після бою з розбійниками, Геральд продовжує свій шлях до селища.";

                story++;
            }
            else if (story == 7)
            {
                BackgroundImage = Properties.Resources.chapter_0_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald_plotva;
                text_history.Text = "Геральд: Чому половина людей, яких я зустрічаю на шляху, відразу вирішують напасти на озброєного відьмака? Може, у мене з обличчям щось не те?";

                story++;
            }

            //Епізод 1
            else if (story == 8)
            {
                BackgroundImage = Properties.Resources.chapter_1_4;
                character.Visible = false;
                text_history.Text = "Геральд приходить в селище і відразу помічає, що атмосфера напружена. Місцеві жителі збираються навколо сільської дошки оголошень.";

                story++;
            }
            else if (story == 9)
            {
                BackgroundImage = Properties.Resources.chapter_1_4_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Це місце виглядає дуже неспокійно. Якщо справді є проблеми з пропажею людей, то мої послуги можуть знадобитися.";

                story++;
            }
            else if (story == 10)
            {
                character.BackgroundImage = Properties.Resources.peasant_1;
                text_history.Text = "Селянин 1: Ось, нарешті, відьмак прийшов! Ми у великій біді. Наші люди зникають, і ми не знаємо, що робити.";

                story++;
            }
            else if (story == 11)
            {
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Не турбуйтесь, я займусь цим. Де саме зникли люди?";

                story++;
            }
            else if (story == 12)
            {
                character.BackgroundImage = Properties.Resources.peasant_2;
                text_history.Text = "Селянин 2: Останнім часом у нас сильні дощі, дров не має. Тому люди пішли у ліс за дровами…";

                story++;
            }
            else if (story == 13)
            {
                character.BackgroundImage = Properties.Resources.peasant_3;
                text_history.Text = "Селянин 3: І не повернулись!!!!";

                story++;
            }
            else if (story == 14)
            {
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Добре. Подивлюсь, що можна зробити.";

                story++;
            }
            else if (story == 15)
            {
                BackgroundImage = Properties.Resources.chapter_1_4;
                character.Visible = false;
                text_history.Text = "Після розмови з мешканцями селища, Геральд вирішує відправитися в ліс.";

                story++;
            }

            //Епізод 2
            else if (story == 16)
            {
                BackgroundImage = Properties.Resources.chapter_2_3;
                text_history.Text = "Геральд заходить в ліс і незабаром натрапляє на тіла зниклих людей. Він роздивляється їх та роздумує.";

                story++;
            }
            else if (story == 17)
            {
                BackgroundImage = Properties.Resources.chapter_2_3_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Це вже не просто пропажа. Це все зробили монстри. Хто ж це може бути? Пропажі у лісі, під час дощу, тіла розідрані… Це Дух Лісу!!! Він буде вбивати людей, якщо люди будуть сюди йти, треба самого його вбити. Для цього потрібно вбити декілька тварин.";

                story++;
            }

            //Епізод 3
            else if (story == 18)
            {
                BackgroundImage = Properties.Resources.chapter_2_3;
                character.Visible = false;
                text_history.Text = "Для призову Духу Лісу, Геральд вирішив вбити декілька кабанів.";

                story++;
            }
            else if (story == 19)
            {
                BackgroundImage = Properties.Resources.chapter_2_3_dark;
                health_Herald.Value = 100;
                health_enemy.Value = 100;

                enemyRobber = false;
                enemyPeasant = false;
                character.Visible = false;
                health_Herald.Visible = true;
                health_enemy.Visible = true;
                thunder.Visible = true;
                martin.Visible = true;
                quen.Visible = true;
                igni.Visible = true;
                kill_Herald.Visible = true;
                kill_Enemy.Visible = true;
                kill_Herald.BackgroundImage = Properties.Resources.herald_kill;
                kill_Enemy.BackgroundImage = Properties.Resources.boar;
                thunder.BackgroundImage = Properties.Resources.thunder;
                martin.BackgroundImage = Properties.Resources.martin;
                quen.BackgroundImage = Properties.Resources.quen;
                igni.BackgroundImage = Properties.Resources.igni;
                kill_Herald.BackgroundImageLayout = ImageLayout.Zoom;
                kill_Enemy.BackgroundImageLayout = ImageLayout.Zoom;
                thunder.BackgroundImageLayout = ImageLayout.Zoom;
                martin.BackgroundImageLayout = ImageLayout.Zoom;
                quen.BackgroundImageLayout = ImageLayout.Zoom;
                igni.BackgroundImageLayout = ImageLayout.Zoom;
                text_history.Text = "!!! БІЙ !!!";

                isBattleInProgress = true;
                kill_Enemy.Enabled = true;
            }
            else if (story == 20)
            {
                BackgroundImage = Properties.Resources.chapter_2_3;
                text_history.Text = "Для призову Духу Лісу, Геральд вирішив вбити декілька кабанів.";

                story = 19;
            }
            else if (story == 21)
            {
                BackgroundImage = Properties.Resources.chapter_2_3_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;

                text_history.Text = "Геральд: Медальйон тремтить. Дух Лісу поруч…";

                story++;
            }
            else if (story == 22)
            {

                health_Herald.Value = 100;
                health_enemy.Value = 100;

                enemyRobber = false;
                enemyPeasant = false;
                character.Visible = false;
                health_Herald.Visible = true;
                health_enemy.Visible = true;
                thunder.Visible = true;
                martin.Visible = true;
                quen.Visible = true;
                igni.Visible = true;
                kill_Herald.Visible = true;
                kill_Enemy.Visible = true;
                kill_Herald.BackgroundImage = Properties.Resources.herald_kill;
                kill_Enemy.BackgroundImage = Properties.Resources.spirit;
                thunder.BackgroundImage = Properties.Resources.thunder;
                martin.BackgroundImage = Properties.Resources.martin;
                quen.BackgroundImage = Properties.Resources.quen;
                igni.BackgroundImage = Properties.Resources.igni;
                kill_Herald.BackgroundImageLayout = ImageLayout.Zoom;
                kill_Enemy.BackgroundImageLayout = ImageLayout.Zoom;
                thunder.BackgroundImageLayout = ImageLayout.Zoom;
                martin.BackgroundImageLayout = ImageLayout.Zoom;
                quen.BackgroundImageLayout = ImageLayout.Zoom;
                igni.BackgroundImageLayout = ImageLayout.Zoom;
                text_history.Text = "!!! БІЙ !!!";

                isBattleInProgress = true;
                kill_Enemy.Enabled = true;
            }
            else if (story == 23)
            {
                BackgroundImage = Properties.Resources.chapter_2_3_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;

                text_history.Text = "Геральд: Медальйон тремтить. Дух Лісу поруч…";
                
                story = 22;
            }

            //Епізод 4
            else if (story == 24)
            {
                BackgroundImage = Properties.Resources.chapter_1_4;
                character.Visible = false;

                text_history.Text = "Після перемоги над Духом Лісу, Геральд повертається до селища.";

                story++;
            }
            else if (story == 25)
            {
                BackgroundImage = Properties.Resources.chapter_1_4_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Дух Лісу більше не загрожує місцевим жителям. Ви можете бути спокійні.";

                story++;
            }
            else if (story == 26)
            {
                character.BackgroundImage = Properties.Resources.peasant_1;

                text_history.Text = "Селянин 1: Відьмак, тут таке діло. Грошей немає, тому ми тебе вб’ємо.";

                story++;
            }
            else if (story == 27)
            {
                health_Herald.Value = 100;
                health_enemy.Value = 100;

                enemyRobber = false;
                enemyPeasant = true;
                character.Visible = false;
                health_Herald.Visible = true;
                health_enemy.Visible = true;
                thunder.Visible = true;
                martin.Visible = true;
                quen.Visible = true;
                igni.Visible = true;
                kill_Herald.Visible = true;
                kill_Enemy.Visible = true;
                kill_Herald.BackgroundImage = Properties.Resources.herald_kill;
                kill_Enemy.BackgroundImage = Properties.Resources.peasant_1;
                thunder.BackgroundImage = Properties.Resources.thunder;
                martin.BackgroundImage = Properties.Resources.martin;
                quen.BackgroundImage = Properties.Resources.quen;
                igni.BackgroundImage = Properties.Resources.igni;
                kill_Herald.BackgroundImageLayout = ImageLayout.Zoom;
                kill_Enemy.BackgroundImageLayout = ImageLayout.Zoom;
                thunder.BackgroundImageLayout = ImageLayout.Zoom;
                martin.BackgroundImageLayout = ImageLayout.Zoom;
                quen.BackgroundImageLayout = ImageLayout.Zoom;
                igni.BackgroundImageLayout = ImageLayout.Zoom;
                text_history.Text = "!!! БІЙ !!!";

                isBattleInProgress = true;
                kill_Enemy.Enabled = true;
            }
            else if (story == 28)
            {
                BackgroundImage = Properties.Resources.chapter_1_4;

                text_history.Text = "Після перемоги над Духом Лісу, Геральд повертається до селища.";

                story = 25;
            }
            else if (story == 29)
            {
                BackgroundImage = Properties.Resources.chapter_1_4;

                text_history.Text = "Після бою з мешканцями селища, Геральд підійшов до селянина, що вижив.";

                story++;
            }
            else if (story == 30)
            {
                BackgroundImage = Properties.Resources.chapter_1_4_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Ну і на, що ви сподівались? Тепер точно гроші платіть.";

                story++;
            }
            else if (story == 31)
            {
                BackgroundImage = Properties.Resources.chapter_1_4;
                character.Visible = false;
                text_history.Text = "Після того, як отримав гроші, Геральд підійшов до Плотви.";

                story++;
            }
            else if (story == 32)
            {
                BackgroundImage = Properties.Resources.chapter_1_4_dark;
                character.Visible = true;
                character.BackgroundImage = Properties.Resources.herald;
                text_history.Text = "Геральд: Ну що, Плотва, пішли далі на завдання.";

                story++;
            }
            else if (story == 33)
            {
                character.BackgroundImage = Properties.Resources.plotva;
                text_history.Text = "Плотва: Пррррр!";

                story++;
            }
            else if (story == 34)
            {
                BackgroundImage = Properties.Resources.chapter_4;
                character.Visible = false;
                text_history.Text = "Так завершилася ця історія про Геральда, який впорався з Духом Лісу та навіть з місцевими, які не хотіли віддавати гроші.";

                story++;
            }
            else if (story == 35)
            {
                text_history.Text = "!!! КІНЕЦЬ !!!";
            }

        }

        private void kill_Enemy_Click(object sender, EventArgs e)
        {
            if (isBattleInProgress)
            {
                HeraldAttack();
            }
        }

        private void HeraldAttack()
        {
            StartHeraldTurn();

            if (health_enemy.Value - 10 >= health_enemy.Minimum)
            {
                health_enemy.Value -= 10;
            }
            else
            {
                health_enemy.Value = health_enemy.Minimum;
            }

            if (health_enemy.Value <= 0) // Перевірка на поразку
            {
                BackgroundImage = Properties.Resources.win;
                health_Herald.Visible = false;
                health_enemy.Visible = false;
                thunder.Visible = false;
                martin.Visible = false;
                quen.Visible = false;
                igni.Visible = false;
                kill_Herald.Visible = false;
                kill_Enemy.Visible = false;
                text_history.Text = "Геральд виграв цей бій!";
                isBattleFinished = true;
                quenActive = false;
                quen_indicator.Visible = false;
                isBattleInProgress = false; // Завершаємо бій

                if (isBattleFinished)
                {
                    foreach (Control control in this.Controls)
                    {
                        control.Enabled = true;
                    }

                    story += 2;
                    return;
                }
            }

            heraldAttackTimer.Stop(); // Зупинка таймеру атаки Геральда
            isHeraldTurn = false; // Передача хід ворогові
            enemyAttackTimer.Start(); // Запуск таймеру атаки ворога
        }

        private void EnemyAttack()
        {
            int damage = random.Next(10, 21);

            if (quenActive) // Перевірка наявності ефекту "quen"
            {
                damage = 0; // Якщо "quen" активний, Геральд не отримує шкоди
                quenActive = false; // Відключаємо ефект "quen" після використання
                quen_indicator.Visible = false;
            }

            int newHealth = health_Herald.Value - damage; // Розрахунок нового значення здоров'я Геральта

            if (newHealth < health_Herald.Minimum)
            {
                newHealth = health_Herald.Minimum;
            }

            health_Herald.Value = newHealth; // Встановлення нового значення здоров'я Геральда

            string geraltPhrase = GetRandomGeraltPhrase();
            text_history.Text = geraltPhrase;

            if (newHealth <= 0)
            {
                BackgroundImage = Properties.Resources.loss;
                health_Herald.Visible = false;
                health_enemy.Visible = false;
                thunder.Visible = false;
                martin.Visible = false;
                quen.Visible = false;
                igni.Visible = false;
                quen_indicator.Visible = false;
                kill_Herald.Visible = false;
                kill_Enemy.Visible = false;
                text_history.Text = "Геральд пав в бою...";
                isBattleInProgress = false;

                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }

                story++;
            }

            enemyAttackTimer.Stop(); // Зупинка таймера атаки ворога
            isHeraldTurn = true; // Передача ходу Геральду
        }

        // Розблокувати кнопки "thunder", "martin", "quen", та "igni" після удару ворога
        private void StartHeraldTurn()
        {
            isHeraldTurn = true;
            thunderUsed = false;
            martinUsed = false;
            quenUsed = false;

            thunder.Enabled = true;
            martin.Enabled = true;
            igni.Enabled = true;
            quen.Enabled = true;
        }

        private void thunder_Click(object sender, EventArgs e)
        {
            if (isBattleInProgress && isHeraldTurn && !thunderUsed)
            {
                if (health_enemy.Value - 20 >= health_enemy.Minimum)
                {
                    health_enemy.Value -= 20;
                }
                else
                {
                    health_enemy.Value = health_enemy.Minimum;
                }

                thunderUsed = true; // Встановити прапор, щоб кнопка була використана
                thunder.Enabled = false;// Заблокувати кнопку
            }
        }

        private void martin_Click(object sender, EventArgs e)
        {
            if (isBattleInProgress && isHeraldTurn && !martinUsed)
            {
                if (health_Herald.Value + 15 <= health_Herald.Maximum)
                {
                    health_Herald.Value += 15;
                }
                else
                {
                    health_Herald.Value = health_Herald.Maximum;
                }

                martinUsed = true;
                martin.Enabled = false;
            }
        }

        private void quen_Click(object sender, EventArgs e)
        {
            if (isBattleInProgress && isHeraldTurn && !quenUsed)
            {
                quen_indicator.BackgroundImage = Properties.Resources.quen;
                quen_indicator.Visible = true;
                quenActive = true;

                string enemyPhrase = GetRandomEnemyPhrase(); // Отримати випадкову фразу ворога

                if (!string.IsNullOrEmpty(enemyPhrase))
                {
                    text_history.Text = enemyPhrase; // Вивести фразу у текстове поле
                }

                quenUsed = true;
                quen.Enabled = false;
            }
        }

        private void igni_Click(object sender, EventArgs e)
        {
            if (isBattleInProgress && isHeraldTurn)
            {
                if (health_enemy.Value - 5 >= health_enemy.Minimum)
                {
                    health_enemy.Value -= 5;
                }
                else
                {
                    health_enemy.Value = health_enemy.Minimum;
                }

                string enemyPhrase = GetRandomEnemyPhrase();

                if (!string.IsNullOrEmpty(enemyPhrase))
                {
                    text_history.Text = enemyPhrase;
                }

                igni.Enabled = false;
            }
        }

        private string GetRandomEnemyPhrase()
        {
            if (enemyRobber == true)
            {
                int index = random.Next(robberPhrases.Count);
                return robberPhrases[index];
            }
            else if (enemyPeasant == true)
            {
                int index = random.Next(peasantPhrases.Count);
                return peasantPhrases[index];
            }
            return ""; // Якщо зображення ворога не відповідає ні "robber", ні "peasant_1"
        }

        private string GetRandomGeraltPhrase()
        {
            int index = random.Next(geraltPhrases.Count);
            return geraltPhrases[index];
        }
    }
}

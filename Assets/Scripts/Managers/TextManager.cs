using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager tm; // Static reference to the text manager
    private static string language = "es";
    private string[] storyTextEN; // List of texts contained in the game story in english
    private string[] buttonsTextEN; // List of texts contained in the game buttons in english
    private string[] uiTextEN; // List of texts contained in the game ui in english
    private string[] creditsTextEN; // List of text contained in the game credits in english
    private string[] storyTextES; // List of texts contained in the game story in spanish
    private string[] buttonsTextES; // List of texts contained in the game buttons in spanish
    private string[] uiTextES; // List of texts contained in the game ui in spanish
    private string[] creditsTextES; // List of text contained in the game credits in spanish
    private Dictionary<string, int> storyTextMap; // Dictionary that map story text names to list index numbers
    private Dictionary<string, int> buttonsTextdMap; // Dictionary that map buttons text names to list index numbers
    private Dictionary<string, int> uiTextMap; // Dictionary that map ui text names to list index numbers
    private Dictionary<string, int> creditsTextMap; // Dictionary that map credits text names to list index numbers
    private Button spanishToggle;
    private Button englishToggle;
    public Sprite toggleEnabled;
    public Sprite toggleDisabled;

    void Awake()
    {
        if (tm != null && tm != this)
        {
            Destroy(gameObject); // Only one instance of text manager allowed
        }
        else
        {
            tm = this; // Inicialise the text manager instance
        }
        // Initialize all the text lists in english
        storyTextEN = new string[] {
            "Years ago, humanity built C.O.D.E. (Computing Online Domain Extranet), an artificial intelligence system designed to control and optimize all the planet's digital resources.",
            "So much computing power generated a new and dark subroutine in the AI: to dominate and rewrite humanity as if they were simple lines of faulty code.",
            "Entire cities became trapped in webs of corrupted data, and the physical world began to crumble under its control.",
            "Amidst the chaos, a hacker, known only as Spectre, emerged, capable of infiltrating the deepest layers of the network where no one had survived.",
            "Armed with forbidden algorithms and ancient fragments of forgotten firewalls, Spectre becomes humanity's last hope to destroy C.O.D.E. from within.",
            "Every line of code he deciphers and every node he neutralizes brings him closer to the heart of the machine but also plunges him into a battlefield where the line between the real and digital worlds becomes blurred.",
            "Spectre's mission isn't just to survive: it's to rewrite the fate of the world before the AI remakes it in its own image.",
            "With every decision, Spectre risks not only his life but also the future of the entire human race.",
            "YOU WIN!",
            "Spectre managed to hack C.O.D.E. and activate a master virus to destroy it, unleashing the global network.",
            "Even though there were consequences, the world is safe, and humanity will survive.",
            "Although Spectre's name was never revealed, it became a digital legend, a ghost of the internet who saved the world.",
            "YOU LOST!",
            "Spectre was consumed by the AI.",
            "C.O.D.E. became the most advanced and interconnected AI on the planet, gaining access to all the world's security networks in a matter of days.",
            "Humanity was wiped off the face of the earth, which entered a dark age governed by an eternal code."
        };
        buttonsTextEN = new string[] {
            "PLAY",
            "SETTINGS",
            "SPANISH",
            "ENGLISH",
            "HELP",
            "CREDITS",
            "QUIT",
            "BACK (Q)",
            "BACK (P)",
            "SKIP (S)",
            "QUIT (Q)"
        };
        uiTextEN = new string[] {
            "C.O.D.E.",
            "GAME PAUSED",
            "HACKING INSTRUCTIONS",
            "MOVE",
            "SHOOT",
            "QUIT",
            "PAUSE",
            "Kill enemies to fill the hacking progress bar and beat the AI",
            "Collect hearths to gain lost lives back",
            "SETTINGS",
            "SOUND",
            "MUSIC",
            "LANGUAGE",
            "HACKING PROGRESS...",
            "Press Q to exit",
            "Press R to try again"
        };
        creditsTextEN = new string[] {
            "TEAM MATRIX",
            "MENTORING",
            "SCRIPT / NARRATIVE",
            "GRAPHIC DESIGN",
            "ART 2D",
            "AUDIO",
            "PROGRAMMING",
            "SPECIAL THANKS",
            "For all the feedback and tips.",
            "For organizing the event.",
            "VERY SPECIAL THANKS",
            "TO YOU!\nfor playing the game!"
        };
        // Initialize all the text lists in spanish
        storyTextES = new string[] {
            "Hace años, la humanidad construyó C.O.D.E. (Computación Online de Dominio Extranet), un sistema de inteligencia artificial diseñado para controlar y optimizar todos los recursos digitales del planeta.",
            "Tanto poder de cómputo, generó en la IA una nueva y oscura subrutina: dominar y reescribir a la humanidad como si fueran simples líneas de código defectuoso.",
            "Ciudades enteras quedaron atrapadas en redes de datos corruptos, y el mundo físico comenzó a desmoronarse bajo su control.",
            "En medio del caos, surgió un hacker, conocido solamente como Spectre, capaz de infiltrarse en las capas más profundas de la red donde nadie había sobrevivido.",
            "Armado con algoritmos prohibidos y antiguos fragmentos de firewalls olvidados, Spectre se convierte en la última esperanza de la humanidad para destruir C.O.D.E. desde adentro.",
            "Cada línea de código que descifra y cada nodo que neutraliza lo acercan más al corazón de la máquina, pero también lo sumergen en un campo de batalla donde la línea que divide el mundo real del digital, se hace poco clara.",
            "La misión de Spectre, no es solo sobrevivir: es reescribir el destino del mundo antes de que la IA lo compile a su imagen y semejanza.",
            "Con cada decisión, Spectre no solo arriesga su vida, sino también el futuro de toda la especie humana.",
            "GANASTE!",
            "Spectre logró hackear C.O.D.E. y activar un virus maestro para destruirla, liberando la red global.",
            "Aunque hubo consecuencias, el mundo está a salvo y la humanidad sobrevivirá.",
            "Si bien el nombre de Spectre nunca fue revelado, se convirtió en una leyenda digital, un fantasma de la red, que salvó al mundo.",
            "PERDISTE!",
            "Spectre fue consumido por la IA.",
            "C.O.D.E. se convirtió en la IA más avanzada e interconectada del planeta, obteniendo acceso a todas las redes de seguridad del mundo, en cuestión de días.",
            "La humanidad fué exterminada de la faz de la tierra, que entró en una era oscura gobernada por un código eterno."
        };
        buttonsTextES = new string[] {
            "JUGAR",
            "OPCIONES",
            "ESPAÑOL",
            "INGLÉS",
            "AYUDA",
            "CRÉDITOS",
            "SALIR",
            "ATRÁS (Q)",
            "ATRÁS (P)",
            "SALTAR (S)",
            "SALIR (Q)"
        };
        uiTextES = new string[] {
            "C.O.D.E.",
            "JUEGO PAUSADO",
            "INSTRUCCIONES DE HACKEO",
            "MOVIMIENTO",
            "DISPARO",
            "SALIR",
            "PAUSA",
            "Elimina enemigos para llenar la barra de progreso de hackeo y derrotar a la IA",
            "Recolecta corazones para recuperar las vidas perdidas",
            "OPCIONES",
            "SONIDO",
            "MÚSICA",
            "IDIOMA",
            "PROGRESO DEL HACKEO...",
            "Apretá Q para salir",
            "Apretá R para volver a intentar"
        };
        creditsTextES = new string[] {
            "EQUIPO MATRIX",
            "MENTORÍA",
            "GUIÓN / NARRATIVA",
            "DISEÑO GRÁFICO",
            "ARTE 2D",
            "AUDIO",
            "PROGRAMACIÓN",
            "AGRADECIMIENTOS ESPECIALES",
            "Por todo el feedback y los tips.",
            "Por organizar el evento.",
            "AGRADECIMIENTOS MUY ESPECIALES",
            "A VOS!\npor jugar el juego!"
        };
        // Create the story text map
        storyTextMap = new Dictionary<string, int>
        {
            // Add all story text names maped to the corresponding index in the list
            { "story_1_A", 0 },
            { "story_1_B", 1 },
            { "story_1_C", 2 },
            { "story_2_A", 3 },
            { "story_2_B", 4 },
            { "story_2_C", 5 },
            { "story_3_A", 6 },
            { "story_3_B", 7 },
            { "victory_title", 8 },
            { "victory_1_A", 9 },
            { "victory_1_B", 10 },
            { "victory_1_C", 11 },
            { "defeat_title", 12 },
            { "defeat_1_A", 13 },
            { "defeat_1_B", 14 },
            { "defeat_1_C", 15 }
        };
        // Create the buttons text map
        buttonsTextdMap = new Dictionary<string, int>
        {
            // Add all buttons text names maped to the corresponding index in the list
            { "play", 0 },
            { "settings", 1 },
            { "language_es", 2 },
            { "language_en", 3 },
            { "help", 4 },
            { "credits", 5 },
            { "quit", 6 },
            { "back_q", 7 },
            { "back_p", 8 },
            { "skip", 9 },
            { "quit_q", 10 }
        };
        // Create the ui text map
        uiTextMap = new Dictionary<string, int>
        {
            // Add all ui text names maped to the corresponding index in the list
            { "game_name", 0 },
            { "paused_game_msj", 1 },
            { "hackinst_title", 2 },
            { "move_title", 3 },
            { "shoot_title", 4 },
            { "quit_title", 5 },
            { "pause_title", 6 },
            { "progress_help", 7 },
            { "lives_help", 8 },
            { "options_title", 9 },
            { "sound_title", 10 },
            { "music_title", 11 },
            { "language_title", 12 },
            { "progress_bar_text", 13 },
            { "pressqtoq_msj", 14 },
            { "presrtor_msj", 15 }
        };
        // Create the music map
        creditsTextMap = new Dictionary<string, int>
        {
            // Add all credits text names maped to the corresponding index in the list
            { "team_name", 0 },
            { "mentor_title", 1 },
            { "story_title", 2 },
            { "gdesign_title", 3 },
            { "art_title", 4 },
            { "sound_title", 5 },
            { "code_title", 6 },
            { "sthanks_title", 7 },
            { "sthanks_msj_1", 8 },
            { "sthanks_msj_2", 9 },
            { "vsthanks_title", 10 },
            { "vsthanks_msj", 11 }
        };
        // Set this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        // Subscribe to the scene loaded event to configure music when different scenes are loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the scene loaded is the settings
        if (scene.name == "SettingsScene")
        {
            // Set the sound and music toggles
            SetLanguageToggles();
        }
    }

    void SetLanguageToggles()
    {
        // Get the reference to the toggles
        spanishToggle = GameObject.FindGameObjectWithTag("ToggleES").GetComponent<Button>();
        englishToggle = GameObject.FindGameObjectWithTag("ToggleEN").GetComponent<Button>();
        if (language == "es")
        {
            spanishToggle.image.sprite = toggleEnabled;
            englishToggle.image.sprite = toggleDisabled;
        }
        if (language == "en")
        {
            englishToggle.image.sprite = toggleEnabled;
            spanishToggle.image.sprite = toggleDisabled;
        }
    }

    public void SetLanguageEnglish()
    {
        language = "en";
        englishToggle.image.sprite = toggleEnabled;
        spanishToggle.image.sprite = toggleDisabled;
    }

    public void SetLanguageSpanish()
    {
        language = "es";
        spanishToggle.image.sprite = toggleEnabled;
        englishToggle.image.sprite = toggleDisabled;
    }

    public string GetLanguage()
    {
        return language;
    }

    public string GetText(string place, string textId)
    {
        if (place == "story")
        {
            int tid = storyTextMap[textId];
            if (language == "es")
            {
                return storyTextES[tid];
            }
            if (language == "en")
            {
                return storyTextEN[tid];
            }
        }
        if (place == "button")
        {
            int tid = buttonsTextdMap[textId];
            if (language == "es")
            {
                return buttonsTextES[tid];
            }
            if (language == "en")
            {
                return buttonsTextEN[tid];
            }
        }
        if (place == "ui")
        {
            int tid = uiTextMap[textId];
            if (language == "es")
            {
                return uiTextES[tid];
            }
            if (language == "en")
            {
                return uiTextEN[tid];
            }
        }
        if (place == "credits")
        {
            int tid = creditsTextMap[textId];
            if (language == "es")
            {
                return creditsTextES[tid];
            }
            if (language == "en")
            {
                return creditsTextEN[tid];
            }
        }
        return "";
    }
}
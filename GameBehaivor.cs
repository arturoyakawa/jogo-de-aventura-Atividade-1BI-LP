using UnityEngine;

public class GameBehaivor : MonoBehaviour
{

    // variables

    [Header("Global")]
    public int heroiVidaBase = 100;
    public int heroiDanoDeAtaque = 20;
    private int heroiVidaAtual;

    [Header("Cenário 1: Vitória")]
    public string tipoDeInimigo1 = "Goblin";
    public int danoDoInimigo1 = 10;
    public int vidaBaseDoInimigo1 = 20;
    public int heroiVidaExtraObtida = 20;
    public bool heroi1PodeMorrer = false;
    public bool inimigo1PodeMorrer = true;

    [Header("Cenário 2: Derrota Parcial")]
    public string tipoDeInimigo2 = "Orc";
    public int danoDoInimigo2 = 20;
    public int vidaBaseDoInimigo2 = 40;
    public bool heroi2PodeMorrer = false;
    public bool inimigo2PodeMorrer = false;

    [Header("Cenário 3: Boss Final")]
    public string tipoDeInimigo3 = "Dragão";
    public int danoDoInimigo3 = 100;
    public int vidaBaseDoInimigo3 = 500;
    public bool heroi3PodeMorrer = true;
    public bool inimigo3PodeMorrer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heroiVidaAtual = heroiVidaBase;
        Debug.Log("O herói entra na masmorra com " + heroiVidaAtual + " de vida...");
        Cenario1();
        Debug.Log("O heroi sai da primeira batalha com " + heroiVidaAtual + " de vida.");
        Cenario2();
        Debug.Log("O heroi sai da segunda batalha com " + heroiVidaAtual + " de vida.");
        Cenario3();
    }
    private int CalculateDamage(int health, int damage, bool canDie)
    {
        int trueHealth = health - damage;
        return trueHealth > 0 ? trueHealth : (canDie ? 0 : 1);
    }
    private void Cenario1()
    {
        Debug.Log("Ele encontra um " + tipoDeInimigo1 + "!");
        heroiVidaAtual = CalculateDamage(heroiVidaAtual, danoDoInimigo1, heroi1PodeMorrer);
        Debug.Log("Os dois entram em uma batalha: O heroi performa um ataque que dá " + heroiDanoDeAtaque + " de dano, deixando o " + tipoDeInimigo1 + " com " + CalculateDamage(vidaBaseDoInimigo1, heroiDanoDeAtaque, inimigo1PodeMorrer) + " de vida, incapaz de continuar lutando.");
        Debug.Log("O heroi vê que o " + tipoDeInimigo1 + " carregava uma poção de cura, que concede " + heroiVidaExtraObtida + " de vida.");
        heroiVidaAtual += heroiVidaExtraObtida;
    }
    private void Cenario2()
    {
        Debug.Log("Ele encontra um " + tipoDeInimigo2 + "!");
        heroiVidaAtual = CalculateDamage(heroiVidaAtual, danoDoInimigo2, heroi2PodeMorrer);
        Debug.Log("Os dois entram em uma batalha: O heroi performa um ataque que dá " + heroiDanoDeAtaque + " de dano, deixando o " + tipoDeInimigo2 + " com " + CalculateDamage(vidaBaseDoInimigo2, heroiDanoDeAtaque, inimigo2PodeMorrer) + " de vida, machucado, mas ainda de pé.");
        Debug.Log("O heroi aproveita a oportunidade e foge.");
    }
    private void Cenario3()
    {
        Debug.Log("Ele encontra um " + tipoDeInimigo3 + "!");
        heroiVidaAtual = CalculateDamage(heroiVidaAtual, danoDoInimigo3, heroi3PodeMorrer);
        Debug.Log("Os dois entram em uma batalha: O heroi performa um ataque que dá " + heroiDanoDeAtaque + " de dano, deixando o " + tipoDeInimigo3 + " com " + CalculateDamage(vidaBaseDoInimigo3, heroiDanoDeAtaque, inimigo3PodeMorrer) + " de vida, não fez nem cossegas!");
        Debug.Log("O heroi, por outro lado, fica com "+ heroiVidaAtual + ", não consegue continuar.");
        Debug.Log("GAME OVER!");
    }
}

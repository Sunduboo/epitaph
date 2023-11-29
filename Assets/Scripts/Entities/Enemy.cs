using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Entity
{   
    public Coin coin;
    [SerializeField] GameObject particles;

    [SerializeField] CoinValueEnum enemyCoinValue;
    private const int minNumberOfCoins = 2;
    private const int maxNumberOfCoins = 4;
    private SpriteRenderer renderer;
    private bool hasDied = false;
    protected override void Start() {
        base.Start();
        renderer = GetComponent<SpriteRenderer>();
    }
    public override void Die() {
        if (!hasDied) {
            DropCoins();
        }
        hasDied = true;
        Destroy(gameObject);
        if (gameObject.name == "Lich") {
            SceneManager.LoadScene(11);
        }
    }

    public override void TakeDamage(float amount) {
        base.TakeDamage(amount);
        if (particles != null){
            GameObject obj = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(obj, 0.4f);
        }

    }

    public void DropCoins() {
        int numberOfCoins = (int) ((Random.value * (maxNumberOfCoins - minNumberOfCoins + 1)) + minNumberOfCoins);
        
        Coin[] copyCoins = new Coin[numberOfCoins];
        
        for (int i = 0; i < numberOfCoins; i++) {
            copyCoins[i] = Instantiate(coin) as Coin;
            copyCoins[i].transform.position = (Vector2) this.transform.position + Random.insideUnitCircle / 2;
            copyCoins[i].GetComponent<Coin>().setCoinValue((int)enemyCoinValue);

            switch (enemyCoinValue) {
                default:
                case CoinValueEnum.SmallValue:
                    copyCoins[i].GetComponent<SpriteRenderer>().sprite = copyCoins[i].SMALL_VALUE_COIN_SPRITE;
                    break;
                case CoinValueEnum.MediumValue:
                    copyCoins[i].GetComponent<SpriteRenderer>().sprite = copyCoins[i].MEDIUM_VALUE_COIN_SPRITE;
                    break;
                case CoinValueEnum.LargeValue:
                    copyCoins[i].GetComponent<SpriteRenderer>().sprite = copyCoins[i].LARGE_VALUE_COIN_SPRITE;
                    break;
            }
        }
    }

}

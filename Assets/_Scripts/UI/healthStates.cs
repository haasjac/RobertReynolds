using UnityEngine;
using System.Collections;

public class together : State {

    healthController hc;

	public together(healthController hc) {
        this.hc = hc;
    }

    public override void OnStart() {
        hc.full.health = Mathf.Max(hc.top.health / hc.top.max_health, hc.bottom.health / hc.bottom.max_health) * hc.full.max_health;
        Vector2 size = hc.FullHealth.GetComponent<RectTransform>().sizeDelta;
        size.x = hc.full.health / hc.full.max_health * 150;
        hc.FullHealth.GetComponent<RectTransform>().sizeDelta = size;
        hc.TopHealth.transform.parent.gameObject.SetActive(false);
        hc.BottomHealth.transform.parent.gameObject.SetActive(false);
        hc.FullHealth.transform.parent.gameObject.SetActive(true);
    }

    public override void OnUpdate(float time_delta_fraction) {
        Vector2 size = hc.FullHealth.GetComponent<RectTransform>().sizeDelta;
        size.x = hc.full.health / hc.full.max_health * 150;
        hc.FullHealth.GetComponent<RectTransform>().sizeDelta = size;
    }

    public override void OnFinish() {
        base.OnFinish();
    }
}

public class apart : State {

    healthController hc;

    public apart(healthController hc) {
        this.hc = hc;
    }

    public override void OnStart() {
        hc.top.health = hc.full.health / hc.full.max_health * hc.top.max_health;
        hc.bottom.health = hc.full.health / hc.full.max_health * hc.bottom.max_health;
        Vector2 size1 = hc.TopHealth.GetComponent<RectTransform>().sizeDelta;
        size1.x = hc.top.health / hc.top.max_health * 150;
        hc.TopHealth.GetComponent<RectTransform>().sizeDelta = size1;
        Vector2 size2 = hc.BottomHealth.GetComponent<RectTransform>().sizeDelta;
        size2.x = hc.bottom.health / hc.bottom.max_health * 150;
        hc.BottomHealth.GetComponent<RectTransform>().sizeDelta = size2;
        hc.TopHealth.transform.parent.gameObject.SetActive(true);
        hc.BottomHealth.transform.parent.gameObject.SetActive(true);
        hc.FullHealth.transform.parent.gameObject.SetActive(false);
    }

    public override void OnUpdate(float time_delta_fraction) {
        Vector2 size1 = hc.TopHealth.GetComponent<RectTransform>().sizeDelta;
        size1.x = hc.top.health / hc.top.max_health * 150;
        hc.TopHealth.GetComponent<RectTransform>().sizeDelta = size1;
        Vector2 size2 = hc.BottomHealth.GetComponent<RectTransform>().sizeDelta;
        size2.x = hc.bottom.health / hc.bottom.max_health * 150;
        hc.BottomHealth.GetComponent<RectTransform>().sizeDelta = size2;
    }

    public override void OnFinish() {
        base.OnFinish();
    }
}

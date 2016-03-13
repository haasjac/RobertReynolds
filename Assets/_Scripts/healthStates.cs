using UnityEngine;
using System.Collections;

public class together : State {

    healthController hc;
    jakePlayer p1;
    jakePlayer p2;

	public together(healthController hc, jakePlayer p1, jakePlayer p2) {
        this.hc = hc;
        this.p1 = p1;
        this.p2 = p2;
    }

    public override void OnStart() {
        p1.health = Mathf.Max(p1.health, p2.health);
        p2.health = Mathf.Max(p1.health, p2.health);
        Vector2 size = hc.BothHealth.GetComponent<RectTransform>().sizeDelta;
        size.x = p1.health * 150;
        hc.BothHealth.GetComponent<RectTransform>().sizeDelta = size;
        hc.OneHealth.transform.parent.gameObject.SetActive(false);
        hc.TwoHealth.transform.parent.gameObject.SetActive(false);
        hc.BothHealth.transform.parent.gameObject.SetActive(true);
    }

    public override void OnUpdate(float time_delta_fraction) {
        Vector2 size = hc.BothHealth.GetComponent<RectTransform>().sizeDelta;
        size.x = p1.health * 150;
        hc.BothHealth.GetComponent<RectTransform>().sizeDelta = size;
    }

    public override void OnFinish() {
        base.OnFinish();
    }
}

public class apart : State {

    healthController hc;
    jakePlayer p1;
    jakePlayer p2;

    public apart(healthController hc, jakePlayer p1, jakePlayer p2) {
        this.hc = hc;
        this.p1 = p1;
        this.p2 = p2;
    }

    public override void OnStart() {
        p2.health = p1.health;
        Vector2 size1 = hc.OneHealth.GetComponent<RectTransform>().sizeDelta;
        size1.x = p1.health * 150;
        hc.OneHealth.GetComponent<RectTransform>().sizeDelta = size1;
        Vector2 size2 = hc.TwoHealth.GetComponent<RectTransform>().sizeDelta;
        size2.x = p2.health * 150;
        hc.TwoHealth.GetComponent<RectTransform>().sizeDelta = size2;
        hc.OneHealth.transform.parent.gameObject.SetActive(true);
        hc.TwoHealth.transform.parent.gameObject.SetActive(true);
        hc.BothHealth.transform.parent.gameObject.SetActive(false);
    }

    public override void OnUpdate(float time_delta_fraction) {
        Vector2 size1 = hc.OneHealth.GetComponent<RectTransform>().sizeDelta;
        size1.x = p1.health * 150;
        hc.OneHealth.GetComponent<RectTransform>().sizeDelta = size1;
        Vector2 size2 = hc.TwoHealth.GetComponent<RectTransform>().sizeDelta;
        size2.x = p2.health * 150;
        hc.TwoHealth.GetComponent<RectTransform>().sizeDelta = size2;
    }

    public override void OnFinish() {
        base.OnFinish();
    }
}

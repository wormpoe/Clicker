using System.Collections.Generic;
using UnityEngine;

public class DpsPower : Power
{
    private Dictionary<DpsUpgradeName, DpsItem> _dpsItem = new Dictionary<DpsUpgradeName, DpsItem>();
    public Dictionary<DpsUpgradeName, DpsItem> DpsItem { get => _dpsItem; }
    protected override void Init()
    {
        var autoTapper = new DpsItem();
        autoTapper.Init(1f);
        _dpsItem[DpsUpgradeName.AutoTapper] = autoTapper;

        var rabbitAlly = new DpsItem();
        rabbitAlly.Init(0.5f);
        _dpsItem[DpsUpgradeName.RabbitAlly] = rabbitAlly;

        var bunnySquad = new DpsItem();
        bunnySquad.Init(2f);
        _dpsItem[DpsUpgradeName.BunnySquad] = bunnySquad;

        var mechanicalHare = new DpsItem();
        mechanicalHare.Init(2f);
        _dpsItem[DpsUpgradeName.MechanicalHare] = mechanicalHare;

        var laserBunny = new DpsItem();
        laserBunny.Init(1f);
        _dpsItem[DpsUpgradeName.LaserBunny] = laserBunny;

        var rabbitLegion = new DpsItem();
        rabbitLegion.Init(0.5f);
        _dpsItem[DpsUpgradeName.RabbitLegion] = rabbitLegion;

        var cosmicFactory = new DpsItem();
        cosmicFactory.Init(2f);
        _dpsItem[DpsUpgradeName.CosmicFactory] = cosmicFactory;

        var infiniteArmy = new DpsItem();
        infiniteArmy.Init(1f);
        _dpsItem[DpsUpgradeName.InfiniteArmy] = infiniteArmy;

        var quantumRabbits = new DpsItem();
        quantumRabbits.Init(0.5f);
        _dpsItem[DpsUpgradeName.QuantumRabbits] = quantumRabbits;

        var realityShredder = new DpsItem();
        realityShredder.Init(2f);
        _dpsItem[DpsUpgradeName.RealityShredder] = realityShredder;

        var dimensionalBurst = new DpsItem();
        dimensionalBurst.Init(1f);
        _dpsItem[DpsUpgradeName.DimensionalBurst] = dimensionalBurst;

        var antimatterRabbits = new DpsItem();
        antimatterRabbits.Init(0.5f);
        _dpsItem[DpsUpgradeName.AntimatterRabbits] = antimatterRabbits;
    }
    public void UpgradeDpsItem(float mantissa, int exponent, DpsUpgradeName dpsUpgradeName)
    {
        if (_dpsItem.ContainsKey(dpsUpgradeName))
        {
            _powerMantissa = _dpsItem[dpsUpgradeName].PowerMantissa;
            _powerExponent = _dpsItem[dpsUpgradeName].PowerExponent;
            UpgradePower(mantissa, exponent);
            _dpsItem[dpsUpgradeName].AddPower(_powerMantissa, _powerExponent);
            _powerMantissa = 0;
            _powerExponent = 0;
            foreach (var powerDps in _dpsItem.Values)
            {
                if (powerDps.PowerMantissa > 0)
                {
                    UpgradePower(powerDps.PowerMantissa / powerDps.TickInterval, powerDps.PowerExponent);
                }
            }
            _signalBus.Fire(new DPSPowerSignal(_powerMantissa, _powerExponent));
        }
    }
    public override void UpgradePower(float mantissa, int exponent)
    {
        base.UpgradePower(mantissa, exponent);
    }
    public Vector3 GenerationRandomPosition(Transform unit, Camera camera)
    {
        Vector3 pos = unit.transform.position;
        var canvasPos = RectTransformUtility.WorldToScreenPoint(camera, pos);
        int radius = Random.Range(30, 50);
        float radians = Random.Range(0, 360) * Mathf.Deg2Rad;
        canvasPos.x += radius * Mathf.Cos(radians);
        canvasPos.y += radius * Mathf.Sin(radians);
        return canvasPos;
    }
}

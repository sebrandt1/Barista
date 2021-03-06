using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barista.Builder
{
    public interface IBeverage
    {
        CupSize Size { get; }
        int Milk { get; }
        int Water { get; }
        Bean Bean { get; }
        int Temperature { get; }

        IBeverage Init();

        IBeverageBuildStageOne AddWater(int x);
    }

    public interface IBeverageBuildStageOne
    {
        IBeverageBuildStageTwo AddBean(Bean x);
    }
    public interface IBeverageBuildStageTwo
    {
        IBeverageBuildStageThree GrindBeans();
    }
    public interface IBeverageBuildStageThree
    {
        IBeverageBuildStageFour AddMilk(int x);
        Coffee Validate(int x);
    }
    public interface IBeverageBuildStageFour
    {
        IBeverageBuildStageFive AddMilkFoam();
        Coffee Validate(int x);
    }
    public interface IBeverageBuildStageFive
    {
        Coffee Validate(int x);
    }
}

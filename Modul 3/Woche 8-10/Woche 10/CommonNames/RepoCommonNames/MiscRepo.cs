using DLCommonNames;
using static TypesCommonNames.Enums;

namespace RepoCommonNames
{
    public class MiscRepo
    {

        public static bool IsKitNrAllowed(string kitNr, Company company, KitType kitType = KitType.Default)
        {
            var result = MiscData.IsKitNrAllowed(kitNr, (int)company, (int)kitType);

            return result;
        }
    }
}

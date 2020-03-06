using System;

namespace Rpg1
{
    class Program
    {
        struct Userstatus
        {
            public int str;
            public int dex;
            public int intel;
            public float money;
            public int rank;
        }
        struct GuildManage
        {
            public int guildcount;
            public string guildrank;
        }
        static void Minimunstat(out Userstatus status)
        {
            status.str = 10;
            status.dex = 10;
            status.intel = 10;
            status.money = 10;
            status.rank = 10;
        }
        static void Guildstat(out GuildManage guildmanage)
        {
            guildmanage.guildcount = 0;
            guildmanage.guildrank = " ";
        }

        static void Checkstatus(ref Userstatus status, ref GuildManage guildmanage)
        {
            Console.WriteLine($" 체력 : {status.str}");
            Console.WriteLine($" 민첩 : {status.dex}");
            Console.WriteLine($" 지능 : {status.intel}");
            Console.WriteLine($" 돈 : {status.money}골드");
            if (status.rank >= 20)
                Console.WriteLine("하급 귀족");
            else if (status.rank >= 30)
                Console.WriteLine("귀족");
            if(guildmanage.guildrank != " ")
                Console.WriteLine(guildmanage.guildrank);
            
        }

        static void Quest(string case1statusS, string case2statusS, string case3statusS,string case1answer, string case2answer, string case3answer,ref Userstatus status)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine(case1answer);
                    status.str += case1statusS[0];
                    status.dex += case1statusS[1];
                    status.intel += case1statusS[2];
                    status.money += case1statusS[3];
                    status.rank += case1statusS[4];
                    break;
                case "2":
                    Console.WriteLine(case2answer);
                    status.str += case2statusS[0];
                    status.dex += case2statusS[1];
                    status.intel += case2statusS[2];
                    status.money += case2statusS[3];
                    status.rank += case2statusS[4];
                    break;
                case "3":
                    Console.WriteLine(case3answer);
                    status.str += case3statusS[0];
                    status.dex += case3statusS[1];
                    status.intel += case3statusS[2];
                    status.money += case3statusS[3];
                    status.rank += case3statusS[4];
                    break;
                default:
                    break;
            }
        }
        static void Tutorial(ref Userstatus status)
        {
            // 질문 5개
            // 질문 1
            Console.WriteLine("왜 x 마을로 가는것이지?\n");
            Console.WriteLine("[1] 말하고 싶지 않다"); // 귀족 루트( 지능 + 2 민첩 + 1 돈 + 2 계급 + 3 )
            Console.WriteLine("[2] 돈 벌려고"); // 모험가 루트 ( 힘 + 3 민첩 + 3  )
            Console.WriteLine("[3] 공부하려고");// 학원 루트 ( 민첩 +1 지능 +3 돈 +3 계급 + 2 )
            string case1statusS = "12345";
            string case2statusS = "12345";
            string case3statusS = "12345";
            string case1answer = "누구는 사연 없는 줄 아쇼?... 갈 길이 머니 물어본 것이지";
            string case2answer = "그래 요새는말이여 돈이 최고지!그런데 요새는 진짜 돈이면 다 되는줄 아는단 말이여";
            string case3answer = "공부 중요하지! 나도 옛날에는말이여~공부을 아주 잘했당께.....";
            Quest(case1statusS,case2statusS,case3statusS, case1answer,case2answer,case3answer,ref status);
            
        }
        static void Lobby(ref Userstatus status,ref GuildManage guildmanage)
        {
            while(true)
            {
                Console.WriteLine("[1] 마을 둘러보기");
                Console.WriteLine("[2] 정보 확인");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        FirstVillage(ref status,ref guildmanage);
                        break;
                    case "2":
                        Checkstatus(ref status,ref guildmanage);
                        break;
                    default:
                        break;
                }
            }
        }
        static void FirstVillage(ref Userstatus status, ref GuildManage guildmanage)
        {
            while (true)
            {
                Console.WriteLine("주점");
                Console.WriteLine("모험가 길드");
                Console.WriteLine("학원");
                Console.WriteLine("");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        Console.WriteLine("모험가 길드로 이동합니다");
                        Guild(ref status, ref guildmanage);
                        break;
                    default:
                        break;
                }
            }
        }
        static void Guild(ref Userstatus status, ref GuildManage guildmanage)
        {
            Console.WriteLine("모험가 길드에 도착했습니다.\n어떤 일을 하시겠습니까?");
            while(true)
            {
                Console.WriteLine("다른 할 일이 있습니까?");
                if(guildmanage.guildcount==0)
                {
                    Console.WriteLine("[1] 길드에 등록하기 (1 골드 소모 )");
                    status.money -= 1;
                    Console.WriteLine("F등급 모험가증을 받았다");
                    guildmanage.guildrank = "F등급 모험가증";
                    while (true)
                    {
                        Console.WriteLine("[1] 질문하기");
                        Console.WriteLine("[2] 모험가 길드에서 나가기");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.WriteLine("[1] 등록하는데 왜 1골드나 되죠?");
                            Console.WriteLine("[2] 제가 할 수 있는 일이 있을까요?");
                            string input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "1":
                                    Console.WriteLine("저희 길드에서는 모험가분이 할 수 있는 일을 중계해드립니다\n낮은 등급에서는 그렇게 많은 돈을 벌지는 못하지만 등급이 오르시면 높은 보상의 일들이 많이 있으므모 결코 손해는 아닙니다.");
                                break;
                                case "2":
                                    Console.WriteLine($"현재 {guildmanage.guildrank}으로 할 수 있는 퀘스트입니다.");
                                    Guildquestlist(ref status, ref guildmanage);
                                break;
                                default:
                                    break;
                            }
                        }
                        else if(input == "2")
                        {
                            Console.WriteLine("모험가 길드에서 나왔습니다. 마을로 돌아왔습니다");
                            FirstVillage(ref status, ref guildmanage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[1] 현재 할 수 있는 퀘스트를 보고 싶습니다");
                    Console.WriteLine("[2] 퀘스트를 완료하고 싶습니다");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine($"현재 {guildmanage.guildrank}으로 할 수 있는 퀘스트입니다.");
                            Guildquestlist(ref status, ref guildmanage);
                            break;
                        case "2":
                            
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        static void Guildquestlist(ref Userstatus status, ref GuildManage guildmanage)
        {
            if(guildmanage.guildrank == "F등급 모험가증")
            {
                
            }
        }
        static void Guildquestmanage()
        {

        }
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("RPG1");
                Console.WriteLine("아무 키나 입력하세요");
                Console.ReadLine();

                Userstatus status;
                GuildManage guildmanage;

                Minimunstat(out status);// 스텟 할당
                Guildstat(out guildmanage); // 길드스텟 할당

                Tutorial(ref status);
                Lobby(ref status, ref guildmanage);
                
            }
        }
    }
}

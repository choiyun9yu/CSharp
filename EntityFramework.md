# Entity Framework

Entity Framework는 객체지향 프로그래밍 언어에서 데이터베이서를 쉽게 사용하기 위한 ORM 도구로서, OOP의 객체와 관계형 데이터베이스의 테이블을 매핑하여 쉽게 데이터에 엑세스할 수 있게 한다.

## 1. Entity Framework 모델
### 1-1. Code First
Code First는 먼저 C# 클래스로 테이블의 구조를 정의하는데, 클래스의 속성을 테이블의 칼럼에 매핑한다. Code First라는 말에서 처럼 이 접근 방식은 DB를 미리 설계하지 않고 C# 클래스들로 Domain Object들을 정의하고 프로그램 실행시 DB가 없으면 자동으로 DB를 생성하는 방식을 취한다.

        [Table("drones")]                                                               // 테이블의 이름을 drones로 지정
        public class Drone
        {
            [Column("id")] public int DroneID { get; set; }                             // "id" 칼럼에 대한 매핑 제공 
            [MaxLength(7)] [Column("drone_code")] public string DroneCode { get; set; } // "drone_code" 칼럼 최대 길이 7로 제한
            [ForeignKey("AreaCode")] public AreaCodeInfo AreaCodeInfo { get; set; }     // "AreaCode" 칼럼을 외래키 지정, 이것은 AreaCodeInfo 객체와 연결된다.
            [Column("max_weight")] public float MaxWeight { get; set; }                 // 
            [Column("is_enabled")] private char isEnabled;                              // 
            [NotMapped]                                                                 // 데이베터이스에 저장되지 않는 프로퍼티 
            public bool IsEnabled                                                       
            {
                get
                {
                    return this.isEnabled != '0';
                }
                set
                {
                    this.isEnabled = value ? '1' : '0';
                }
            }
            [Column("created_at")] public DateTime CreatedAt { get; set; }              // 데이터가 생성된 날짜 및 시간을 저장
            [ForeignKey("created_by")] public User CreatedBy { get; set; }              // 외래키로 User 객체와 연결
        }

### 1-2. Model First

### 1-3. Database First

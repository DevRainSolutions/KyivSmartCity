using System.Collections.Generic;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public class EnDataSource
    {
        public List<Group> GetGroups()
        {
            return new List<Group>
            {
                new Group
                {
                    Title = "Kyiv Smart City Strategy Development",
                    Description =
                        "The primary goal is to create the development strategy for Kyiv within the concept of the “smart city”.",
                    Id = 1,
                    TeamMember = new TeamMember
                    {
                      Name  = "Podhorna Viktoriia",
                      Description = "Executive Director of the “Hormadska Rada Smart City” non-governmental organization, Doctor of Philosophy. Member of the “Reanimation Package of Reforms” civic initiative – Kyiv. Member of the Smart Group Working Group at Kyiv City State Administration, the initiator of the first Hackathon in “Kyiv Smart City”.",
                      ImageUrl = "/Images/team/viktoria.png"
                    },
                    Body = @"The main directions of the strategic planning are the following:”.

1. Economy of the city consists in enabling of the transfoprmability of the city, the penetration of ICT, attraction of investments, support of the innovative ventures, development of the city’s economy on the basis of the knowledge-based economy.
2. Urban management – the e-governance and e-democracy, the transparent allocation of funds and the public participation in the city management, the e-services.
3. Smart people – online participation in urban management, the educational opportunities for youth and new qualifications, the development of the creative economy. 
4. Safety and health – provision of the high level of the personal security of the city dwellers, innovations in public health system, improvement of the quality of housing conditions.
5. Infrastructure of the city and the environment – the urban development, green technologies, energy efficiency, management of the city environmental resources (water, soil, air, waste), the ecology (monitoring and protection of the environment), installation of the sensory monitoring and control system.
6. Mobility – ICT development, availability of wi-fi, mobile applications, the well-developed, innovative and safe public transportation system of the city.
7. The period of the work over the strategy development is about 4 months. The big companies, activists, and the concerned Kyiviens take the active part in consideration of this strategy development."
                },

                new Group
                {
                    Title = "Relationships with vendors and system integrators",
                    Description =
                        "The special emphasis in Smart City is placed on the business development, as well as development of the city through the creation of the favorable business infrastructure.",
                    Id = 2,
                    Body = @"In this context the investment, technological and intellectual capacities of the modern innovative business, on the one hand, and the organization capacities of the city management, on the other hand, can promote the successful implementation of the “Smart City Strategy” in Kyiv. 

The “Smart City Kyiv” model should single out 6 main fields, which are the most important for the modern big city on implementation of the “Smart City” concept:

1. **Smart economy** – the intellectual economy or the competitiveness of the city:
 - Development of the entrepreneurship, establishment of the municipal centers of support of the small and medium-sized businesses’ sector;
 - Establishment of the co-working centers;
 - Development and dissemination of the economic information;
 - Economic development, including the international economic development;
 - Accessibility of the public information, including the facilitation of performance of the business activities (e.g., the geoinformation systems) – the city as “data platform”.
2. **Smart people** – the intelligent thinkers, i.e., the social and human capital:
 - Improvement of the affordability of the vocational training for various groups of the city dwellers (e.g., the municipal Vocational Training Center); 
 - Establishment of the system of uninterrupted education (the city as the knowledge sharing center);
 - Prevention of social isolation, including the digital isolation (modern municipal libraries, public access t - computers and t - Internet); 
 - Support of the non-governmental organizations.
3. **Smart governance** – the intelligent management, i.e., the participation of citizens in the  decision-making process in the city:
 - Broadening of the city dwellers’ participation in the decision-making process (system of consultancies with community, applications for communication with local population);
 - Providing of the complete information on services, offered by the city;
 - Transparency of management (the information systems of the decision-making process, the network access t - the information for dwellers, consulting systems).
4. **Smart mobility** – the intellectual mobility – the transport and aspects, related t - the ICT development and application:
 - Modernization of the municipal transport (the modern fleet of vehicles, traffic management, passage tickets, auxiliary services, public transport flexible timetable, intermodal and multimodal solutions);
 - City traffic management (the software for the traffic management, the mathematical modeling, public information systems)
 - ICT system modernization (the network solutions in administrating, the systems of the city Internet)
 - Modernization of the network access infrastructure (the optical fiber, the network management control)
 - Enabling access t - the urban infrastructure services; 
 - Enabling of the broadband access for the enterprises and inhabitants; the city Wi-Fi zone.
5. **Smart environment** – the intellectual environment and environment-related aspects:
 - Environmental quality monitoring (the pollution measurement systems, threat prevention, public environmental information system);
 - Modern power generation systems (the solar systems, photovoltaic power systems, heat pumps, biogas systems);
 - Thermo-modernization of the buildings (the modernization of the public buildings, the support of the private residences’ modernization, dissemination of the energy management certification); 
 - City green spaces enhancement; 
 - Development of the modern water supply facilities and sewerage systems (the monitoring systems, modern systems of the water treatment and waste water purification, the water consumption curtail, effluent management systems).
6. **Smart living** – the smart life and improvement of the life quality of the inhabitants and of the  quality of the delivered public services: 
 - Improvement of the culture level of the city (the system of the integrated resource management, network resources use); 
 - Improvement of the education system (the standardization, digital education’s development, educational isolation prevention, promotion of the modern competences in economy, based on knowledge, the care of the gifted students);
 - Improvement of the public health system (the facilitation of access t - the medical services, the municipal healthcare information system, the prophylaxis of diseases);
 - Improvement of the spatial planning (the maps’ digitizing, the zoning monitoring etc.);
 - Improving of the safety of inhabitants (the monitoring systems, alarm, communications systems).

If You represent:

 - the company, possessing the ready-made solutions within the scope of the “Smart City Kyiv”;
 - the fund, ready t - allocate the financing for the project;  
 - the organization, experienced in implementation of the similar concepts; 
 - or You are just interested in working in this group,

please contact us.",
                    TeamMember = new TeamMember
                    {
                      Name  = "Biriukov Andrii",
                      Description = "Expert in ICT and electronic payment systems. President of the “IT-Alliance” non-governmental organization. Manager of the activities, related t - the ІТ business and international financial institutions.",
                      ImageUrl = "/Images/team/andriy.jpg"
                    },
                },

                new Group
                {
                    Title = "Relationships with ІТ-community in development of the city services",
                    Description =
                        "The members of the IT-community will be extensively involved int - the “Smart City Kyiv” development.",
                    Id = 3,
                    Body = @"First of all, the “Smart City” concept is based on the use of the modern information technologies. This is why the members of the IT-community will be extensively involved in development of the “Smart City Kyiv” project.

The group activities will include:

- the work over the creation of the city projects’ catalogue, the mobile applications for the “Smart City” site;
- the realization of the themed hackathons for development of the applications, required for improvement of the life quality of the inhabitants and guests of Kyiv city;
- The development and creation of the series of the ІТ solutions, meeting the needs of the Kyiviens;

If You are: 

- the member of the IT-community;
- the adherent of the “smart technology solutions” for improvement and facilitation of the everyday’s life around You;
- or if You just have the potential for development of this direction, 

please contact us.",
                    TeamMember = new TeamMember
                    {
                      Name  = "Krakovetskyi Oleksandr",
                      Description = "CEO of DevRain Solutions, PhD. in Computer Sciences, Microsoft Regional Director, Microsoft Most Valuable Professional.",
                      ImageUrl = "/Images/team/alex.png"
                    },
                },
                 new Group
                {
                    Title = "Smart City Kyiv School",
                    Description =
                        "The school is organized in format of the series of lectures, delivered by the invited Ukrainian and international experts in city development, ICT implementation, and the urban planning.",
                    Id = 4,
                    Body = @"Any changes are impossible without educational component. This is why we decided to create the program, within the scope of which we will present, discuss and create our own vision of the smart city. The program is organized in format of the series of lectures, delivered by the invited Ukrainian and international experts in city development, ICT implementation, and the urban planning, which will share their experience in implementation of the “Smart City” concept.",
                     TeamMember = new TeamMember
                    {
                      Name  = "Moyseyenko Anton",
                      Description = "Entrepreneur, social activist, expert of the Kyiv city Council of Urbanistics. Co-coordinator of the “Kyiv Smart City” project.",
                      ImageUrl = "/Images/team/anton.jpg"
                    },
                },
            };
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ContactApp.Core.Domain.Customers;
using ContactApp.Core.Domain.Enquiries;

namespace ContactApp.Data.Initializer
{
    public class ContactAppDbInitializer
    {
        private static ContactAppContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            // ContactUsContext registered as a scoped service and access it here outside
            // of a scope, so first create a scope and then intialize database.
            using (var scope = serviceProvider.CreateScope())
            {
                var Provider = scope.ServiceProvider;

                try
                {
                    context = (ContactAppContext)Provider.GetService(typeof(ContactAppContext));

                    //automatic update DB to latest migration
                    //context.Database.Migrate();

                    //Delete & create new database.
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    InitializeSchedules();
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<ContactAppDbInitializer>>();
                    logger.LogError(ex, $"{Environment.NewLine}An error occurred seeding the DB  ==>  { ex.Message}");
                }
            }
        }

        private static void InitializeSchedules()
        {
            //if (!context.Set<Customer>().Any())
            if (!context.Customers.Any())
            {

                Customer[] customers = new Customer[]
                {
                    new Customer()
                    {
                        FirstName = "Mattie",
                        LastName = "Lyons",
                        Email = "mattie@abc.com",
                        UserName = "MattieLyons",
                        Gender = "Female",
                        Avatar = "avatarf_01.png",
                        Enquiries = new List<Enquiry>
                        {
                            new Enquiry() { Title = "Mattie: Duis finibus velit", Message = "Duis finibus velit vitae turpis sollicitudin, non condimentum lacus facilisis. Nullam congue dictum ullamcorper. Pellentesque nec tristique massa. In auctor tempor lectus. Proin interdum condimentum commodo. Nulla sapien erat, convallis ut malesuada vel, dignissim eu lacus. Proin felis augue, facilisis vel maximus non, mattis convallis nulla."},
                            new Enquiry() { Title = "Mattie: Etiam eu metus congue", Message = "Etiam eu metus congue, hendrerit ex eu, condimentum ex. Aenean eget dapibus velit, at mattis libero. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur iaculis quam eu tellus rhoncus euismod. Phasellus vestibulum suscipit augue in ultrices. Nullam congue molestie lectus, vitae aliquet purus tincidunt eget."},
                            new Enquiry() { Title = "Mattie: Cras molestie aliquam", Message = "Cras molestie aliquam massa sed vestibulum. Nulla facilisi. Morbi finibus massa sed congue maximus. Sed non ligula neque. Donec vel erat et ipsum mattis posuere. Aenean ullamcorper dictum urna at iaculis. Duis luctus arcu eu sem sagittis, et consequat lacus venenatis. Sed et velit vel dolor porttitor lacinia in vitae sapien. Suspendisse congue ante eget mi aliquam sollicitudin."},
                        }
                    },
                    new Customer()
                    {
                        FirstName = "Chris",
                        LastName = "Donald",
                        Email = "chris@abc.com",
                        UserName = "ChrisDonald",
                        Gender = "Male",
                        Avatar = "avatarm_01.png",
                        Enquiries = new List<Enquiry>
                        {
                            new Enquiry() { Title = "Chris: Lorem ipsum dolor", Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam fermentum dictum mauris, sed dictum nunc sollicitudin eget. Curabitur porttitor felis vitae imperdiet euismod. Sed condimentum turpis id nulla elementum, vel bibendum massa tempor. In hac habitasse platea dictumst. Nulla laoreet turpis sed urna blandit efficitur. Nam quis cursus mauris, ac lobortis metus. Sed eget turpis lectus."},
                            new Enquiry() { Title = "Chris: Morbi mollis porta libero", Message = "Morbi mollis porta libero, finibus viverra mi convallis vitae. Nullam ultrices ante vitae velit volutpat consequat. Nam finibus fringilla libero at luctus. Donec consectetur orci pretium velit imperdiet, quis vestibulum mi malesuada. Fusce vitae mi purus. Mauris purus neque, volutpat id lectus porttitor, lacinia gravida est. Aenean pulvinar arcu eu velit ultrices sagittis. Aliquam eget ligula auctor, volutpat purus in, egestas urna"},
                            new Enquiry() { Title = "Chris: Fusce vitae dignissim magna", Message = "Fusce vitae dignissim magna. Vestibulum scelerisque quis dui in venenatis. Fusce non ornare elit. Praesent sed tortor laoreet, consectetur ipsum nec, vehicula nulla. Aliquam neque ipsum, tincidunt ac orci volutpat, aliquam tincidunt velit. Nulla vel suscipit metus, eget vestibulum nunc. Integer feugiat auctor nibh, sagittis tristique neque dictum a. Sed luctus nisl sit amet nisl sollicitudin commodo nec ac mauris."},
                        }
                    },
                    new Customer()
                    {
                        FirstName = "Kelly",
                        LastName = "Alvarez",
                        Email = "kelly@abc.com",
                        UserName = "KellyAlvarez",
                        Gender = "Female",
                        Avatar = "avatarf_02.png",
                        Enquiries = new List<Enquiry>
                        {
                            new Enquiry() { Title = "Kelly: Nam dictum ex quis", Message = "Nam dictum ex quis ultrices gravida. Nullam eget porta mauris. Nunc tristique nec ante ut consectetur. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque a lorem consequat, consectetur ipsum at, fermentum nibh."},
                            new Enquiry() { Title = "Kelly: Donec vel placerat purus", Message = "Donec vel placerat purus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec vitae turpis ligula. Nam erat sem, vulputate et nisi at, pretium tincidunt urna"},
                            new Enquiry() { Title = "Kelly: Pellentesque dictum aliquet dapibus", Message = "Pellentesque dictum aliquet dapibus. Cras fringilla convallis urna, vel semper justo faucibus sed. Aenean porttitor est at risus placerat egestas. Cras feugiat facilisis turpis sit amet luctus. Cras et quam ac leo faucibus posuere. Nunc eu diam vel turpis aliquet cursus at bibendum sem."},
                        }
                    },
                    new Customer()
                    {
                        FirstName = "Marks",
                        LastName = "Todd",
                        Email = "marks@abc.com",
                        UserName = "MarksTodd",
                        Gender = "Male",
                        Avatar = "avatarm_02.png",
                        Enquiries = new List<Enquiry>
                        {
                            new Enquiry() { Title = "Marks: Nam diam magna, elementum", Message = "Nam diam magna, elementum at condimentum quis, consectetur quis purus. Fusce et leo pharetra lacus laoreet sagittis ac sed augue. In dui dolor, viverra non risus quis, euismod sollicitudin mi. Maecenas tristique leo neque, in laoreet diam dictum vitae. Ut euismod ipsum in dictum imperdiet."},
                            new Enquiry() { Title = "Marks: Nulla scelerisque ac elit vel egestas", Message = "Nulla scelerisque ac elit vel egestas. Fusce cursus sit amet nibh ac auctor. Fusce hendrerit quis nulla ut condimentum. Morbi condimentum mollis quam, sit amet varius ex fermentum a. Ut sit amet volutpat dui. Etiam sed ultrices mi. Quisque interdum magna ut ullamcorper mattis. Integer venenatis quam nec nulla ullamcorper aliquam."},
                            new Enquiry() { Title = "Marks: Curabitur hendrerit mollis dui", Message = "Curabitur hendrerit mollis dui, vitae pulvinar est fringilla quis. Donec eu nisi vitae nulla semper tristique vitae id arcu. Pellentesque aliquet leo a sapien finibus, in volutpat ante accumsan. Suspendisse potenti. Mauris eu massa velit. Vivamus tincidunt cursus nisl ac venenatis. Nulla ante quam, molestie non nunc sit amet, blandit blandit arcu. Proin tincidunt purus eget quam faucibus bibendum."},
                        }
                    },
                    new Customer()
                    {
                        FirstName = "Megan ",
                        LastName = "Fox",
                        Email = "megan@abc.com",
                        UserName = "MeganFox",
                        Gender = "Female",
                        Avatar = "avatarf_03.png",
                        Enquiries = new List<Enquiry>
                        {
                            new Enquiry() { Title = "Megan: Etiam et tincidunt augue", Message = "Etiam et tincidunt augue, ac tincidunt nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer molestie sed velit nec commodo. Nulla nec pretium neque. Proin a scelerisque odio. Quisque interdum risus felis, vel placerat lectus scelerisque at."},
                            new Enquiry() { Title = "Megan: Phasellus vitae elit varius", Message = "Phasellus vitae elit varius, imperdiet massa ac, lobortis purus. Fusce dapibus maximus leo suscipit ornare. Curabitur cursus consequat risus, vitae ullamcorper neque sodales dictum. Maecenas sit amet luctus enim. Nunc id sem sed odio convallis faucibus a vel nisl. Ut a nibh posuere neque facilisis ultricies et quis dui."},
                            new Enquiry() { Title = "Megan: Morbi egestas fermentum viverra", Message = "Morbi egestas fermentum viverra. Curabitur lobortis, justo et dignissim scelerisque, ante tellus lacinia sem, ut congue dolor purus non ante. Aenean convallis euismod justo, ut varius nibh tempor in. Etiam ornare quis massa eget tempus. Mauris rutrum dignissim leo, ut scelerisque augue ornare id. Aenean venenatis urna vitae odio aliquam elementum ac a diam. Sed vestibulum congue euismod."},
                        }
                    }
                };

                context.Set<Customer>().AddRange(customers);
                context.SaveChanges();
            }
        }
    }
}

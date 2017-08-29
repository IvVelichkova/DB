using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    class InvitationCofiguration:EntityTypeConfiguration<Invitation>
    {
        public InvitationCofiguration()
        {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
namespace NClass.Core
{
    public class ProjectCore
    {
        string projectFile;
        XmlDocument document;
        List<Entity> entities;
        RelationCollection relations;
        Language language;

        public ProjectCore(Language language)
        {
            this.language = language;
            projectFile = null;
            entities = new List<Entity>();
            relations = new RelationCollection();
            document = new XmlDocument();
        }

        /// <exception cref="IOException">
        /// Could not load the project.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// The save file is corrupt and could not load.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="fileName"/> is empty string.
        /// </exception>
        public ProjectCore(string fileName)
        {
            entities = new List<Entity>();
            relations = new RelationCollection();
            document = new XmlDocument();
            Load(fileName);
        }

        public IEnumerable<Entity> Entities
        {
            get
            {
                for (int i = 0; i < entities.Count; i++)
                    yield return entities[i];
            }
        }

        public IEnumerable<Relation> Relations
        {
            get
            {
                for (int i = 0; i < relations.Count; i++)
                    yield return relations[i];
            }
        }

        public string ProjectFile
        {
            get
            {
                return projectFile;
            }
        }

        public Language Language
        {
            get
            {
                return language;
            }
        }

        protected virtual void AddEntity(Entity entity)
        {
            if (entity != null)
                entities.Add(entity);
        }

        /// <exception cref="ArgumentException">
        /// Cannot create relationship between the two entities.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> is null.-or-
        /// <paramref name="second"/> is null.
        /// </exception>
        public Relation AddRelation(Entity first, Entity second, RelationType relationType)
        {
            return relations.Add(first, second, relationType);
        }

        /// <exception cref="BadSyntaxException">
        /// The <paramref name="name"/> does not fit to the syntax.
        /// </exception>
        public ClassType AddClass(string name)
        {
            ClassType newClass;
            newClass = new CSharpClass(name);
            AddEntity(newClass);

            return newClass;
        }

        /// <exception cref="InvalidOperationException">
        /// <see cref="Language"/> is <see cref="Language.Java"/>.
        /// </exception>
        /// <exception cref="BadSyntaxException">
        /// The <paramref name="name"/> does not fit to the syntax.
        /// </exception>
        public StructType AddStruct(string name)
        {
            StructType newStruct;

            if (Language == Language.CSharp)
            {
                newStruct = new StructType(name);
            }
            else
            {
                throw new InvalidOperationException("error_cannot_create_struct");
            }
            AddEntity(newStruct);

            return newStruct;
        }

        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
            relations.Remove(entity);
        }

        public void RemoveRelation(Relation relation)
        {
            relations.Remove(relation);
        }

        public virtual void NewProject()
        {
            entities.Clear();
            relations.Clear();
            projectFile = null;
        }

        public virtual void NewProject(Language language)
        {
            this.language = language;
            NewProject();
        }

        /// <exception cref="IOException">
        /// Could not load the project.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// The save file is corrupt and could not load.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="fileName"/> is empty string.
        /// </exception>
        public virtual void Load(string fileName)
        {
            NewProject();

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("error_blank_filename");

            if (!File.Exists(fileName))
            {
                NewProject();
                throw new FileNotFoundException("error_file_not_found");
            }

            try
            {
                document.Load(fileName);
            }
            catch (XmlException ex)
            {
                NewProject();
                throw new IOException("error_could_not_load_file" + ex.Message);
            }

            XmlElement root = document["ClassProject"];

            if (root == null)
                throw new InvalidDataException("error_corrupt_savefile");

            try
            {
                Deserialize(root);
            }
            catch (InvalidDataException ex)
            {
                NewProject();
                throw new InvalidDataException("error_corrupt_savefile" + ex.Message);
            }

            projectFile = fileName;
        }

        /// <exception cref="InvalidDataException">
        /// The save format is corrupt and could not load.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="root"/> is null.
        /// </exception>
        protected virtual void Deserialize(XmlNode root)
        {
            if (root == null)
                throw new ArgumentNullException("root");

            XmlElement child = root["Language"];

            try
            {
                language = (Language)Enum.Parse(typeof(Language), child.InnerText);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidDataException("error_corrupt_save_format" + ex.Message);
            }

            LoadEntitites(root);
            LoadRelations(root);
        }

        /// <exception cref="InvalidDataException">
        /// The save format is corrupt and could not load.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="root"/> is null.
        /// </exception>
        private void LoadEntitites(XmlNode root)
        {
            if (root == null)
                throw new ArgumentNullException("root");

            XmlElement entitiesChild = root["Entities"];
            XmlElement child = null;

            if (entitiesChild != null)
                child = entitiesChild["Entity"];

            while (child != null)
            {
                if (child.Name == "Entity")
                {
                    string name = child.GetAttribute("name");
                    string type = child.GetAttribute("type");

                    try
                    {
                        Entity entity = TypeHelper.GetEntityFromType(type, name);
                        entity.Deserialize(child);
                        entities.Add(entity);
                    }
                    catch (ArgumentException ex)
                    {
                        throw new InvalidDataException("error_corrupt_save_format" + ex.Message);
                    }
                    catch (BadSyntaxException ex)
                    {
                        throw new InvalidDataException("error_corrupt_save_format" + ex.Message);
                    }
                    child = child.NextSibling as XmlElement;
                }
            }
        }

        /// <exception cref="InvalidDataException">
        /// The save format is corrupt and could not load.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="root"/> is null.
        /// </exception>
        private void LoadRelations(XmlNode root)
        {
            if (root == null)
                throw new ArgumentNullException("root");

            XmlElement entitiesChild = root["Relations"];
            XmlElement child = null;

            if (entitiesChild != null)
                child = entitiesChild["Relation"];

            while (child != null)
            {
                if (child.Name == "Relation")
                {
                    string type = child.GetAttribute("type");
                    string first = child.GetAttribute("first");
                    string second = child.GetAttribute("second");
                    int firstIndex, secondIndex;

                    if (!int.TryParse(first, out firstIndex) ||
                        !int.TryParse(second, out secondIndex))
                    {
                        throw new InvalidDataException("error_corrupt_save_format");
                    }

                    try
                    {
                        Relation relation = relations.Add(entities[firstIndex],
                            entities[secondIndex], TypeHelper.ParseRelationType(type));
                        relation.Deserialize(child);
                    }
                    catch (ArgumentException ex)
                    {
                        throw new InvalidDataException("error_corrupt_save_format" + ex.Message);
                    }
                }
                child = child.NextSibling as XmlElement;
            }
        }

        /// <exception cref="IOException">
        /// Could not save the project.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The project was not saved before by the <see cref="Save(string)"/> method.
        /// </exception>
        public virtual bool Save()
        {
            if (ProjectFile == null)
                throw new InvalidOperationException("error_cannot_save_file");

            Save(ProjectFile);

            return true;
        }

        /// <exception cref="IOException">
        /// Could not save the project.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="fileName"/> is empty string.
        /// </exception>
        protected virtual void Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("error_blank_filename");

            document.RemoveAll();
            XmlElement root = document.CreateElement("ClassProject");
            document.AppendChild(root);

            Serialize(root);

            try
            {
                document.Save(fileName);
            }
            catch (XmlException ex)
            {
                throw new IOException("error_could_not_save_file" + ex.Message);
            }
            projectFile = fileName;
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="root"/> is null.
        /// </exception>
        protected virtual void Serialize(XmlNode root)
        {
            if (root == null)
                throw new ArgumentNullException("root");

            XmlElement child = document.CreateElement("Language");
            child.InnerText = Language.ToString();
            root.AppendChild(child);

            SaveEntitites(root);
            SaveRelations(root);
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="root"/> is null.
        /// </exception>
        private void SaveEntitites(XmlNode root)
        {
            if (root == null)
                throw new ArgumentNullException("root");

            XmlElement entitiesChild = document.CreateElement("Entities");

            for (int i = 0; i < entities.Count; i++)
            {
                XmlElement child = document.CreateElement("Entity");

                entities[i].Serialize(child);
                if (entities[i] is TypeBase)
                    child.SetAttribute("name", ((TypeBase)entities[i]).Name);
                child.SetAttribute("type", entities[i].GetType().Name);
                entitiesChild.AppendChild(child);
            }
            root.AppendChild(entitiesChild);
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="root"/> is null.
        /// </exception>
        private void SaveRelations(XmlNode root)
        {
            if (root == null)
                throw new ArgumentNullException("root");

            XmlElement relationsChild = document.CreateElement("Relations");

            foreach (Relation relation in relations)
            {
                XmlElement child = document.CreateElement("Relation");

                int firstIndex = entities.IndexOf(relation.First);
                int secondIndex = entities.IndexOf(relation.Second);

                relation.Serialize(child);
                child.SetAttribute("type", relation.GetType().Name);
                child.SetAttribute("first", firstIndex.ToString());
                child.SetAttribute("second", secondIndex.ToString());
                relationsChild.AppendChild(child);
            }
            root.AppendChild(relationsChild);
        }
    }
}
